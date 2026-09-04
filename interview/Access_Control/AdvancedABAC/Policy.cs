public class Policy
{
    public string Name { get; }

    public string Description { get; }
    
    public PolicyEffect Effect { get; }
    
    public int Priority { get; }

    public Func<User, Resource, Permission, bool> Condition { get; }

    public Policy(
        string name,
        string description,
        int priority,
        PolicyEffect effect,
        Func<User, Resource, Permission, bool> condition)
    {
        Name = name;
        Description = description;
        Effect = effect;
        Priority = priority;
        Condition = condition;
    }
}