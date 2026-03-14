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