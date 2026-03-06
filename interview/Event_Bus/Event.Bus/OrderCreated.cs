namespace Event.Bus;

public class OrderCreated
{
    public string OrderId { get; }

    public OrderCreated(string orderId)
    {
        OrderId = orderId;
    }
}