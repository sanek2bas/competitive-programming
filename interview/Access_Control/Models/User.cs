
public class User
{
    public int Id { get; }
    
    public string Username { get; set; }

    public string Department { get; set; }
    
    public List<Role> Roles { get; }

    public User(
        int id, 
        string userName,
        string department)
    {
        Id = id;
        Username = userName;
        Department = department;
        Roles = new List<Role>();
    }
}
