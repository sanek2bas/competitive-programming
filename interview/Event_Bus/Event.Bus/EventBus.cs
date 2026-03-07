using System.Collections.Concurrent;
using Microsoft.VisualBasic;

namespace Event.Bus;

public class EventBus : IEventBus
{
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
    }

    public void Publish(OrderCreated @event)
    {
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));

        var currentHandlers = handlers.Values.ToArray();
        
        if (currentHandlers.Length == 0)
            return;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
