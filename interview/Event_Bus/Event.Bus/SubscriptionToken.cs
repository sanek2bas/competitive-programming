namespace Event.Bus;

public class SubscriptionToken : ISubscriptionToken
{
    public Guid Id { get; }

    public bool IsDisposed { get; private set; }

    public SubscriptionToken()
    {
        Id = Guid.NewGuid();
    }

    public void Dispose()
    {
        IsDisposed = false;
    }
}