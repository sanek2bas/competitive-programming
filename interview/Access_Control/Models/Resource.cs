public class Resource
{
    public int Id { get; }

    public string Type { get; }

    public string Name { get; set; }
    
    public string Owner { get; }
    
    public string Department { get; set; }
    
    public DateTime CreatedDate { get; }    
    
    public bool IsPublic { get; set; }
    
    public Dictionary<string, object> Attributes { get; }
    
    public Resource(
        int id, 
        string type,
        string name,
        string owner,
        string department,
        DateTime createdDate,
        bool isPublic)
    {
        Id = id;
        Type = type;
        Name = name;
        Owner = owner;
        Department = department;
        CreatedDate = createdDate;
        IsPublic = isPublic;
        Attributes = new Dictionary<string, object>();
    }
}