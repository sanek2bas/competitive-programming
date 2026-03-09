using System.Collections.Concurrent;
using Microsoft.VisualBasic;

namespace Event.Bus;

public class EventBus : IEventBus
{
    private struct Subscription(ISubscriptionToken Token, Action<OrderCreated> Handler);
    private readonly ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>> handlers;
    private bool disposed;

    public EventBus()
    {
        handlers = 
            new ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>>();
    }    

    public ISubscriptionToken Subscribe(Action<OrderCreated> handler)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (handler == null)
            throw new ArgumentNullException(nameof(handler));

        var token = new SubscriptionToken();
        handlers.TryAdd(token, handler);

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (token == null)
            throw new ArgumentNullException(nameof(token));
        
        handlers.TryRemove(token, out var handler);
        token.Dispose();
    }

    public void Publish(OrderCreated @event)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));
            
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));

        var currentTokenHandlers = handlers.ToArray();
        if (currentTokenHandlers.Length == 0)
            return;

        Task.Run(async () =>
        {
            foreach (var tokenHandler in currentTokenHandlers)
            {
                if (!tokenHandler.Key.IsActive)
                    continue;
                tokenHandler.Value.Invoke(@event);
            }    
        });
    }

    private async Task PublishAsync(OrderCreated @event)
    {
        
    }

    public void Dispose()
    {
        if (disposed)
            return;
        handlers.Clear();
        disposed = true;
    }
}
