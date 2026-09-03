public class ExtendedUser : User
{
    public Dictionary<string, object> Attributes { get; }

    public ExtendedUser(int id, string name, string department)
        : base(id, name, department)
    {
        Attributes = new Dictionary<string, object>();
    }
}