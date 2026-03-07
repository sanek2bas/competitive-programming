using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading.Channels;

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
