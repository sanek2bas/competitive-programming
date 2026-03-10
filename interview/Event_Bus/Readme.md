Задача на одном из собеседований в Яндекс

Реализовать паттерн sub/prod

interface IEventBus : IDisposable
{
    ISubscriptionToken Subscribe(Action<OrderCreated> handler);
    void Unsubscribe(ISubscriptionToken token);
    void Publish(OrderCreated @event);
}

ISubscriptionToken
{
}

class OrderCreated
{
    public string OrderId { get; }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading.Tasks;

public interface IEventBus : IDisposable
{
    ISubscriptionToken Subscribe<T>(Func<T, Task> handler);
    void Unsubscribe(ISubscriptionToken token);
    void Publish<T>(T @event);
}

public interface ISubscriptionToken
{
    Guid Id { get; }
    Type EventType { get; }
}

public sealed class SubscriptionToken : ISubscriptionToken
{
    public Guid Id { get; } = Guid.NewGuid();
    public Type EventType { get; }

    public SubscriptionToken(Type eventType)
    {
        EventType = eventType;
    }
}

public sealed class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, ImmutableDictionary<Guid, Func<object, Task>>> _handlers
        = new();

    public ISubscriptionToken Subscribe<T>(Func<T, Task> handler)
    {
        var token = new SubscriptionToken(typeof(T));

        _handlers.AddOrUpdate(
            typeof(T),
            _ => ImmutableDictionary<Guid, Func<object, Task>>
                .Empty
                .Add(token.Id, e => handler((T)e)),
            (_, existing) => existing.Add(token.Id, e => handler((T)e))
        );

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        if (token == null) return;

        if (_handlers.TryGetValue(token.EventType, out var handlers))
        {
            var updated = handlers.Remove(token.Id);

            if (updated.IsEmpty)
                _handlers.TryRemove(token.EventType, out _);
            else
                _handlers[token.EventType] = updated;
        }
    }

    public void Publish<T>(T @event)
    {
        if (!_handlers.TryGetValue(typeof(T), out var handlers))
            return;

        foreach (var handler in handlers.Values)
        {
            _ = ExecuteHandler(handler, @event);
        }
    }

    private static async Task ExecuteHandler(Func<object, Task> handler, object evt)
    {
        try
        {
            await handler(evt);
        }
        catch (Exception ex)
        {
            // логирование ошибки
            Console.Error.WriteLine(ex);
        }
    }

    public void Dispose()
    {
        _handlers.Clear();
    }
}

using System;
using System.Threading.Tasks;
using Xunit;

public class EventBusTests
{
    [Fact]
    public async Task Publish_Should_Invoke_Handler()
    {
        var bus = new EventBus();

        var tcs = new TaskCompletionSource<string>();

        bus.Subscribe<OrderCreated>(e =>
        {
            tcs.SetResult(e.OrderId);
            return Task.CompletedTask;
        });

        bus.Publish(new OrderCreated("42"));

        var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Equal("42", result);
    }

    [Fact]
    public async Task Publish_Should_Invoke_Multiple_Handlers()
    {
        var bus = new EventBus();

        var tcs1 = new TaskCompletionSource();
        var tcs2 = new TaskCompletionSource();

        bus.Subscribe<OrderCreated>(e =>
        {
            tcs1.SetResult();
            return Task.CompletedTask;
        });

        bus.Subscribe<OrderCreated>(e =>
        {
            tcs2.SetResult();
            return Task.CompletedTask;
        });

        bus.Publish(new OrderCreated("1"));

        await Task.WhenAll(
            tcs1.Task.WaitAsync(TimeSpan.FromSeconds(2)),
            tcs2.Task.WaitAsync(TimeSpan.FromSeconds(2))
        );
    }

    [Fact]
    public async Task Unsubscribe_Should_Stop_Handler()
    {
        var bus = new EventBus();

        var called = false;

        var token = bus.Subscribe<OrderCreated>(e =>
        {
            called = true;
            return Task.CompletedTask;
        });

        bus.Unsubscribe(token);

        bus.Publish(new OrderCreated("1"));

        await Task.Delay(300);

        Assert.False(called);
    }

    [Fact]
    public async Task Publish_Should_Not_Block_Caller()
    {
        var bus = new EventBus();

        var tcs = new TaskCompletionSource();

        bus.Subscribe<OrderCreated>(async e =>
        {
            await Task.Delay(500);
            tcs.SetResult();
        });

        var start = DateTime.UtcNow;

        bus.Publish(new OrderCreated("1"));

        var elapsed = DateTime.UtcNow - start;

        Assert.True(elapsed < TimeSpan.FromMilliseconds(50));

        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(2));
    }

    [Fact]
    public async Task Dispose_Should_Stop_Processing()
    {
        var bus = new EventBus();

        var called = false;

        bus.Subscribe<OrderCreated>(e =>
        {
            called = true;
            return Task.CompletedTask;
        });

        bus.Dispose();

        bus.Publish(new OrderCreated("1"));

        await Task.Delay(200);

        Assert.False(called);
    }
}


using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

public interface IEventBus : IDisposable
{
    ISubscriptionToken Subscribe<T>(Func<T, Task> handler);
    void Unsubscribe(ISubscriptionToken token);
    void Publish<T>(T @event);
}

public interface ISubscriptionToken
{
    Guid Id { get; }
    Type EventType { get; }
}

public sealed class SubscriptionToken : ISubscriptionToken
{
    public Guid Id { get; } = Guid.NewGuid();
    public Type EventType { get; }

    public SubscriptionToken(Type type)
    {
        EventType = type;
    }
}

internal sealed class EventEnvelope
{
    public Type Type { get; }
    public object Payload { get; }

    public EventEnvelope(Type type, object payload)
    {
        Type = type;
        Payload = payload;
    }
}

public sealed class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<Type, ImmutableDictionary<Guid, Func<object, Task>>> _handlers = new();

    private readonly Channel<EventEnvelope> _channel;
    private readonly CancellationTokenSource _cts = new();
    private readonly Task _worker;

    public EventBus()
    {
        _channel = Channel.CreateUnbounded<EventEnvelope>(
            new UnboundedChannelOptions
            {
                SingleReader = true,
                SingleWriter = false
            });

        _worker = Task.Run(ProcessEvents);
    }

    public ISubscriptionToken Subscribe<T>(Func<T, Task> handler)
    {
        var token = new SubscriptionToken(typeof(T));

        _handlers.AddOrUpdate(
            typeof(T),
            _ => ImmutableDictionary<Guid, Func<object, Task>>
                .Empty
                .Add(token.Id, e => handler((T)e)),
            (_, existing) => existing.Add(token.Id, e => handler((T)e)));

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        if (!_handlers.TryGetValue(token.EventType, out var handlers))
            return;

        var updated = handlers.Remove(token.Id);

        if (updated.IsEmpty)
            _handlers.TryRemove(token.EventType, out _);
        else
            _handlers[token.EventType] = updated;
    }

    public void Publish<T>(T @event)
    {
        _channel.Writer.TryWrite(new EventEnvelope(typeof(T), @event));
    }

    private async Task ProcessEvents()
    {
        try
        {
            await foreach (var envelope in _channel.Reader.ReadAllAsync(_cts.Token))
            {
                if (!_handlers.TryGetValue(envelope.Type, out var handlers))
                    continue;

                foreach (var handler in handlers.Values)
                {
                    try
                    {
                        await handler(envelope.Payload);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _channel.Writer.TryComplete();
        _worker.Wait();
    }
}