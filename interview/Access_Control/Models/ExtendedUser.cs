public class ExtendedUser : User
{
    public Dictionary<string, object> Attributes { get; }

    public ExtendedUser(int id, string name, string role)
        : base(id, name, role)
    {
        Attributes = new Dictionary<string, object>();
    }
}