namespace Event.Bus;

public interface ISubscriptionToken
{
    Guid TokenId { get; }
}
