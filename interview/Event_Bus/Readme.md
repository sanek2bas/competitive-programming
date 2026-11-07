# Задача на одном из собеседований в Яндекс

## Реализовать паттерн sub/prod

```csharp
interface IEventBus : IDisposable
{
    ISubscriptionToken Subscribe(Action<OrderCreated> handler);
    void Unsubscribe(ISubscriptionToken token);
    void Publish(OrderCreated @event);
}
```

```csharp
ISubscriptionToken
{
}
```

```csharp
class OrderCreated
{
    public string OrderId { get; }
}
```