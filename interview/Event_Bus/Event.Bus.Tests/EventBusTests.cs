using Event.Bus;

namespace Event.Bus.Tests;

public class EventBusTests
{
    [Fact]
    public void Publish_Should_Invoke_Handler()
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
        Thread.Sleep(100);
        
        Assert.True(handlerCalled);
        Assert.Equal("123", orderId);
        Assert.NotNull(token);
    }

    [Fact]
    public void Publish_Should_Invoke_Multiple_Handlers()
    {
        using var eventBus = new EventBus();

        var order1Id = string.Empty;
        var token1 = eventBus.Subscribe(order => 
        {
            order1Id = order.OrderId;
        });
        
        eventBus.Publish(new OrderCreated("123"));
        Thread.Sleep(100);
        
        Assert.True(handlerCalled);
        Assert.Equal("123", orderId);
        Assert.NotNull(token);
    }
}
