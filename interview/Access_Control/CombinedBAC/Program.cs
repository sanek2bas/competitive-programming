using ABAC;

public class Program
{
    static void Main(string[] args)
    {
        var admin = new User(1, "AdminUser", "IT");
        admin.Roles.Add(Role.Admin);

        var manager = new User(2, "ManagerUser", "HR");
        admin.Roles.Add(Role.Manager);

        var regularUser = new User(3, "RegularUser", "Sales");
        admin.Roles.Add(Role.User);

        var guest = new User(4, "GuestUser", "Marketing");
        admin.Roles.Add(Role.Guest);

        var publicResource = new Resource(
            1, "Document", "Public Document", "AdminUser", "IT", DateTime.Now, true);
        publicResource.Attributes.Add("Sensitivity", "Public");
        publicResource.Attributes.Add("Version", 1.0);

        var privateResource = new Resource(
            2, "Document", "Private Document", "ManagerUser", "HR", DateTime.Now, false);
        privateResource.Attributes.Add("Sensitivity", "Confidential");
        privateResource.Attributes.Add("Version", 2.0);

        var executeResource  = new Resource(
            3, "Script", "Script", "AdminUser", "IT", DateTime.Now, false);
        executeResource.Attributes.Add("Sensitivity", "Internal");
        executeResource.Attributes.Add("Version", 3.0);

        var rbac = new RBAC.Service();
        var abac = new ABAC.Service();
        var combinedService = new Service(rbac, abac);
        Console.WriteLine("Combined Access Tests:");
        
        Console.WriteLine(
            $"User Read Public: {combinedService.HasAccess(regularUser, publicResource, Permission.Read)}");
        Console.WriteLine(
            $"User Delete Public: {combinedService.HasAccess(regularUser, publicResource, Permission.Delete)}");
        Console.WriteLine(
            $"Manager Read Private: {combinedService.HasAccess(manager, privateResource, Permission.Read)}");
        Console.WriteLine(
            $"Admin Delete Private: {combinedService.HasAccess(admin, privateResource, Permission.Delete)}");
    }
}