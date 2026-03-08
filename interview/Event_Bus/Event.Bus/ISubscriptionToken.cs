namespace Event.Bus;

public interface ISubscriptionToken : IDisposable
{
    Guid Id { get; }

    bool IsDisposed { get; }
}
