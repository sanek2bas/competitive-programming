using Event.Bus;

namespace Event.Bus.Tests;

public class EventBusTests
{
    [Fact]
    public void Subscribe_AddsHandler_WhenHandlerProvided()
    {
        using var eventBus = new EventBus();
        var handlerCalled = false;
        var orderId = string.Empty;
        
        var token = eventBus.Subscribe(order => 
        {
            handlerCalled = true;
            orderId = order.OrderId;
        });
        
        eventBus.Publish(new OrderCreated("123"));
        Thread.Sleep(10000);
        
        Assert.True(handlerCalled);
        Assert.Equal("123", orderId);
        Assert.NotNull(token);
    }
}
