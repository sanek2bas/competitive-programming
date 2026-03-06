using System.Collections.Concurrent;

namespace Event.Bus;

public class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<Guid, Subscription> subscriptions;

    public EventBus()
    {
        subscriptions = new ConcurrentDictionary<Guid, Subscription>();
    }

    

    public ISubscriptionToken Subscribe(Action<OrderCreated> handler)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(EventBus));

        if (handler == null)
            throw new ArgumentNullException(nameof(handler));

        var tokenId = Guid.NewGuid();
        var subscription = new Subscription(tokenId, handler);

        _subscriptions.TryAdd(tokenId, subscription);

        return new SubscriptionToken(() => Unsubscribe(tokenId));
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        throw new NotImplementedException();
    }

    public void Publish(OrderCreated @event)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
