using System.Collections.Concurrent;

namespace Event.Bus;

public class EventBus : IEventBus
{
    private record Subscription(ISubscriptionToken Token, Action<OrderCreated> Handler);
    private readonly ConcurrentDictionary<ISubscriptionToken, Subscription> subscriptions;
    private bool disposed;

    public EventBus()
    {
        subscriptions = new ConcurrentDictionary<ISubscriptionToken, Subscription>();
    }    

    public ISubscriptionToken Subscribe(Action<OrderCreated> handler)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (handler == null)
            throw new ArgumentNullException(nameof(handler));

        var token = new SubscriptionToken();
        var subscription = new Subscription(token, handler);
        _ = subscriptions.TryAdd(token, subscription);

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (token == null)
            throw new ArgumentNullException(nameof(token));
        
        if (subscriptions.TryRemove(token, out var handler))
            token.Dispose();
    }

    public void Publish(OrderCreated @event)
    {
        if (disposed)
            throw new ObjectDisposedException(nameof(EventBus));
            
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));

        var currentSubscriptions = subscriptions.Values.ToArray();
        if (currentSubscriptions.Length == 0)
            return;

        Task.Run(() =>
        {
            foreach (Subscription currentSubscription in currentSubscriptions)
            {
                if (!currentSubscription.Token.IsDisposed)
                    continue;
                currentSubscription.Handler.Invoke(@event);
            }    
        });
    }

    public void Dispose()
    {
        if (disposed)
            return;
        subscriptions.Clear();
        disposed = true;
    }
}
