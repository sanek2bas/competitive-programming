using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;

namespace Event.Bus;

public class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>> handlersDic;
    private readonly Channel<OrderCreated> channel;
    private readonly CancellationTokenSource cts;
    private readonly Task worker;
    private bool disposed;

    public EventBus()
    {
        handlersDic = new ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>>();
        //channel = Channel.CreateUnbounded<OrderCreated>();
        //cts = new CancellationTokenSource();
        //worker = Task.Run(Process);
    }

    public ISubscriptionToken Subscribe(Action<OrderCreated> handler)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (handler == null)
            throw new ArgumentNullException(nameof(handler));

        var token = new SubscriptionToken();
        handlersDic.AddOrUpdate(token, handler, (token, oldValue) => handler);

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (token == null)
            throw new ArgumentNullException(nameof(token));
        
        handlersDic.TryRemove(token, out var handler);
    }

    public void Publish(OrderCreated @event)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));
            
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));

        foreach (var handler in handlersDic.Values)
        {
            _ = ExecuteHandler(handler, @event);
        }
    }

    private async Task Process()
    {
        try
        {
            await foreach(var evnt in channel.Reader.ReadAllAsync(cts.Token))
            {
                var handlers = handlersDic.Values.ToList();
                foreach(Action<OrderCreated> handler in handlers)
                    handler(evnt);
            }
        }
        catch(OperationCanceledException ex)
        {
            
        }
    }
    private static async Task ExecuteHandler(Action<OrderCreated> handler, OrderCreated evt)
    {
        try
        {
            await Task.Run(() => handler(evt));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

    public void Dispose()
    {
        if (disposed)
            return;
        handlersDic.Clear();
        disposed = true;
    }
}
