namespace Event.Bus;

public interface IEventBus : IDisposable
{
    ISubscriptionToken Subscribe(Action<OrderCreated> handler);
    void Unsubscribe(ISubscriptionToken token);
    void Publish(OrderCreated @event);
}