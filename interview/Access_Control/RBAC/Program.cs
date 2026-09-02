public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== RBAC Example ===");

        var admin = new User(1, "AdminUser");
        admin.Roles.Add("Admin");
        admin.Department = "IT";

        var manager = new User(2, "ManagerUser");
        admin.Roles.Add("Manager");
        admin.Department = "HR";

        var regularUser = new User(3, "RegularUser");
        admin.Roles.Add("User");
        admin.Department = "Sales";

        var guest = new User(4, "GuestUser");
        admin.Roles.Add("Guest");
        admin.Department = "Marketing";
        
        var rbacService = new Service();
        Console.WriteLine("RBAC Permission Tests:");
        Console.WriteLine($"Admin Has Write Permission: {rbacService.HasPermission(admin, Permission.Write)}");
        Console.WriteLine($"Admin Has Delete Permission: {rbacService.HasPermission(admin, Permission.Delete)}");
        Console.WriteLine($"Regular User Has Delete Permission: {rbacService.HasPermission(regularUser, Permission.Delete)}");
        Console.WriteLine($"Guest Has Write Permission: {rbacService.HasPermission(guest, Permission.Write)}");

        Console.WriteLine("\n=== ABAC Example ===\n");
    }
}