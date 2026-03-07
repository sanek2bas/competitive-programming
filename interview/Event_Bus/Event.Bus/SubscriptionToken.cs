namespace Event.Bus;

public class SubscriptionToken : ISubscriptionToken
{
    public Guid Id { get; }

    public SubscriptionToken()
    {
        Id = Guid.NewGuid();
    }
}