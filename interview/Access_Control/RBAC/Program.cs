using RBAC;

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
        
        var rbacService = new Service();
        Console.WriteLine("RBAC Permission Tests:");
        
        Console.WriteLine(
            $"Admin Has Write Permission: + {rbacService.HasPermission(admin, Permission.Write)}");
        Console.WriteLine(
            $"Admin Has Delete Permission: {rbacService.HasPermission(admin, Permission.Delete)}");
        Console.WriteLine(
            $"Regular User Has Delete Permission: {rbacService.HasPermission(regularUser, Permission.Delete)}");
        Console.WriteLine(
            $"Guest Has Write Permission: {rbacService.HasPermission(guest, Permission.Write)}");
    }
}