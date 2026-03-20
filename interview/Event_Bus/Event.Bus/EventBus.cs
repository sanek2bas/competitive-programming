using System.Collections.Concurrent;
using System.Diagnostics;

namespace interview.Event.Bus;

public class EventBus : IEventBus
{
    private readonly ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>> handlers;
    private bool disposed;

    public EventBus()
    {
        handlers = new ConcurrentDictionary<ISubscriptionToken, Action<OrderCreated>>();
    }

    public ISubscriptionToken Subscribe(Action<OrderCreated> handler)
    {
        //if (disposed)
        //    throw new ObjectDisposedException(nameof(EventBus));

        //if (handler == null)
        //    throw new ArgumentNullException(nameof(handler));

        var token = new SubscriptionToken();
        handlers.AddOrUpdate(token, handler, (token, oldValue) => handler);

        return token;
    }

    public void Unsubscribe(ISubscriptionToken token)
    {
        //if (disposed)
        //    throw new ObjectDisposedException(nameof(EventBus));

        //if (token == null)
        //    throw new ArgumentNullException(nameof(token));
        
        handlers.TryRemove(token, out var handler);
    }

    public void Publish(OrderCreated @event)
    {
        //if (disposed)
        //    throw new ObjectDisposedException(nameof(EventBus));
            
        //if (@event == null)
        //    throw new ArgumentNullException(nameof(@event));

        foreach (var handler in handlers.Values)
        {
            _ = ExecuteHandler(handler, @event);
        }
    }

    private async Task ExecuteHandler(
        Action<OrderCreated> handler, 
        OrderCreated evt)
    {
        try
        {
            await Task.Run(() => handler(evt));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }

    public void Dispose()
    {
        if (disposed)
            return;
        handlers.Clear();
        disposed = true;
    }
}
