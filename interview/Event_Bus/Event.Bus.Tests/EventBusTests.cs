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

        var tcs1 = new TaskCompletionSource<string>();
        var tcs2 = new TaskCompletionSource<string>();

        var token1 = eventBus.Subscribe(order => 
        {
            tcs1.SetResult("action1");
        });
        var token2 = eventBus.Subscribe(order =>
        {
            tcs2.SetResult("action2");
        });
        
        eventBus.Publish(new OrderCreated("1"));
        Thread.Sleep(100);
        
        Assert.True(tcs1.Task.IsCompleted);
        Assert.Equal("action1", tcs1.Task.Result);
        Assert.True(tcs2.Task.IsCompleted);
        Assert.Equal("action2", tcs2.Task.Result);
    }

    [Fact]
    public void Unsubscribe_Should_Stop_Handler()
    {
        var eventBus = new EventBus();
        var called = false;

        var token = eventBus.Subscribe(
            order => called = true);
        eventBus.Unsubscribe(token);
        
        eventBus.Publish(new OrderCreated("1"));
        Thread.Sleep(100);

        Assert.False(called);
    }
}
