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

// 1. Модель сообщения
public record UserLoggedInEvent(string Username, DateTime Time);

// 2. Интерфейс Хаба
public interface IEventHub
{
    void Publish<T>(T @event);
    void Subscribe<T>(Func<T, Task> handler);
}

// 3. Реализация Хаба
public class InMemoryEventHub : IEventHub
{
    // Используем Channel для асинхронной очереди
    private readonly Channel<object> _channel = Channel.CreateUnbounded<object>();
    private readonly ConcurrentBag<Delegate> _handlers = new();

    public InMemoryEventHub()
    {
        // Фоновая обработка сообщений
        Task.Run(async () =>
        {
            await foreach (var @event in _channel.Reader.ReadAllAsync())
            {
                foreach (var handler in _handlers)
                {
                    if (handler is Func<object, Task> h)
                        _ = h(@event); // Fire-and-forget обработка
                }
            }
        });
    }

    public void Publish<T>(T @event)
    {
        _channel.Writer.TryWrite(@event);
    }

    public void Subscribe<T>(Func<T, Task> handler)
    {
        _handlers.Add(async (obj) =>
        {
            if (obj is T typedEvent)
            {
                await handler(typedEvent);
            }
        });
    }
}

// 4. Использование
public class Program
{
    public static async Task Main()
    {
        var hub = new InMemoryEventHub();

        // Подписка
        hub.Subscribe<UserLoggedInEvent>(async (e) =>
        {
            await Task.Delay(100); // Имитация работы
            Console.WriteLine($"[Подписчик 1] Пользователь {e.Username} вошел в {e.Time}");
        });

        // Публикация (асинхронно)
        hub.Publish(new UserLoggedInEvent("Ivan", DateTime.Now));
        hub.Publish(new UserLoggedInEvent("Maria", DateTime.Now));

        await Task.Delay(1000); // Дать время на обработку
    }
}


[Fact]
    public void Subscribe_AddsHandler_WhenHandlerProvided()
    {
        // Arrange
        using var eventBus = new EventBus();
        var handlerCalled = false;
        
        // Act
        var token = eventBus.Subscribe(order => 
        {
            handlerCalled = true;
        });
        
        eventBus.Publish(new OrderCreated("123"));
        
        // Даем время на асинхронную обработку
        Thread.Sleep(100);
        
        // Assert
        Assert.True(handlerCalled);
        Assert.NotNull(token);
    }

    [Fact]
    public void Subscribe_MultipleHandlers_AllCalled()
    {
        // Arrange
        using var eventBus = new EventBus();
        var callCount1 = 0;
        var callCount2 = 0;
        
        // Act
        eventBus.Subscribe(order => 
        {
            Interlocked.Increment(ref callCount1);
        });
        
        eventBus.Subscribe(order => 
        {
            Interlocked.Increment(ref callCount2);
        });
        
        eventBus.Publish(new OrderCreated("123"));
        
        // Даем время на асинхронную обработку
        Thread.Sleep(100);
        
        // Assert
        Assert.Equal(1, callCount1);
        Assert.Equal(1, callCount2);
    }

    [Fact]
    public void Unsubscribe_RemovesHandler_WhenTokenProvided()
    {
        // Arrange
        using var eventBus = new EventBus();
        var callCount = 0;
        
        var handler = (OrderCreated order) => 
        {
            Interlocked.Increment(ref callCount);
        };
        
        // Act
        var token = eventBus.Subscribe(handler);
        eventBus.Publish(new OrderCreated("123"));
        Thread.Sleep(100);
        
        eventBus.Unsubscribe(token);
        eventBus.Publish(new OrderCreated("456"));
        Thread.Sleep(100);
        
        // Assert
        Assert.Equal(1, callCount);
    }

    [Fact]
    public void Publish_WithSlowHandler_DoesNotBlock()
    {
        // Arrange
        using var eventBus = new EventBus();
        var mainThreadId = Thread.CurrentThread.ManagedThreadId;
        var handlerThreadId = 0;
        
        eventBus.Subscribe(order => 
        {
            Thread.Sleep(1000);
            handlerThreadId = Thread.CurrentThread.ManagedThreadId;
        });
        
        // Act
        var startTime = DateTime.Now;
        eventBus.Publish(new OrderCreated("123"));
        var publishDuration = (DateTime.Now - startTime).TotalMilliseconds;
        
        // Assert
        Assert.True(publishDuration < 100); // Публикация не должна ждать
        Thread.Sleep(1100); // Ждем завершения обработчика
        Assert.NotEqual(mainThreadId, handlerThreadId); // Обработчик выполняется в другом потоке
    }

    [Fact]
    public void Publish_HandlerThrows_ContinuesProcessing()
    {
        // Arrange
        using var eventBus = new EventBus();
        var secondHandlerCalled = false;
        
        eventBus.Subscribe(order => 
        {
            throw new InvalidOperationException("Test exception");
        });
        
        eventBus.Subscribe(order => 
        {
            secondHandlerCalled = true;
        });
        
        // Act
        eventBus.Publish(new OrderCreated("123"));
        Thread.Sleep(100);
        
        // Assert
        Assert.True(secondHandlerCalled);
    }

    [Fact]
    public void ConcurrentPublish_HandlesMultiplePublishers()
    {
        // Arrange
        using var eventBus = new EventBus();
        var callCount = 0;
        var iterations = 10;
        
        eventBus.Subscribe(order => 
        {
            Interlocked.Increment(ref callCount);
            Thread.Sleep(10); // Симулируем работу
        });
        
        // Act
        var threads = new List<Thread>();
        for (int i = 0; i < iterations; i++)
        {
            var orderId = i.ToString();
            var thread = new Thread(() => eventBus.Publish(new OrderCreated(orderId)));
            threads.Add(thread);
            thread.Start();
        }
        
        foreach (var thread in threads)
        {
            thread.Join();
        }
        
        // Даем время на завершение асинхронной обработки
        Thread.Sleep(500);
        
        // Assert
        Assert.Equal(iterations, callCount);
    }

    [Fact]
    public void Subscribe_NullHandler_ThrowsArgumentNullException()
    {
        // Arrange
        using var eventBus = new EventBus();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            eventBus.Subscribe(null));
    }

    [Fact]
    public void Unsubscribe_NullToken_ThrowsArgumentNullException()
    {
        // Arrange
        using var eventBus = new EventBus();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            eventBus.Unsubscribe(null));
    }

    [Fact]
    public void Publish_NullEvent_ThrowsArgumentNullException()
    {
        // Arrange
        using var eventBus = new EventBus();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => 
            eventBus.Publish(null));
    }

    [Fact]
    public void Dispose_MultipleTimes_DoesNotThrow()
    {
        // Arrange
        var eventBus = new EventBus();
        
        // Act
        eventBus.Dispose();
        
        // Assert
        var exception = Record.Exception(() => eventBus.Dispose());
        Assert.Null(exception);
    }

    [Fact]
    public void Dispose_PreventsNewPublications()
    {
        // Arrange
        var eventBus = new EventBus();
        
        // Act
        eventBus.Dispose();
        
        // Assert
        Assert.Throws<ObjectDisposedException>(() => 
            eventBus.Publish(new OrderCreated("123")));
    }

    [Fact]
    public void TokenDispose_RemovesSubscription()
    {
        // Arrange
        using var eventBus = new EventBus();
        var callCount = 0;
        
        var token = eventBus.Subscribe(order => 
        {
            Interlocked.Increment(ref callCount);
        });
        
        // Act
        eventBus.Publish(new OrderCreated("123"));
        Thread.Sleep(100);
        token.Dispose();
        eventBus.Publish(new OrderCreated("456"));
        Thread.Sleep(100);
        
        // Assert
        Assert.Equal(1, callCount);
    }

    [Fact]
    public void Publish_OrderIsDeliveredToAllSubscribers()
    {
        // Arrange
        using var eventBus = new EventBus();
        string receivedOrderId1 = null;
        string receivedOrderId2 = null;
        
        eventBus.Subscribe(order => 
        {
            receivedOrderId1 = order.OrderId;
        });
        
        eventBus.Subscribe(order => 
        {
            receivedOrderId2 = order.OrderId;
        });
        
        // Act
        var testOrderId = "test-123";
        eventBus.Publish(new OrderCreated(testOrderId));
        Thread.Sleep(100);
        
        // Assert
        Assert.Equal(testOrderId, receivedOrderId1);
        Assert.Equal(testOrderId, receivedOrderId2);
    }
}
