namespace Event.Bus;

public class Subscription : ISubscriptionToken
{
    public Guid TokenId { get; }

    public Subscription()
    {
        TokenId = Guid.NewGuid();
    }
}
