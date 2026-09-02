
public class User
{
    public int Id { get; }
    
    public string Username { get; set; }
    
    public List<string> Roles { get; }
    
    public string Department { get; set; }

    public User(int id, string userName)
    {
        Id = id;
        Username = userName;
        Roles = new List<string>();
    }
}
