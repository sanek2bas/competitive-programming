public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Advanced ABAC with Policy Engine ===");

        var admin = new ExtendedUser(1, "AdminUser", "IT");
        admin.Roles.Add(Role.Admin);
        admin.Attributes.Add("Age", 35);
        admin.Attributes.Add("ClearanceLevel", 5);

        var manager = new ExtendedUser(2, "ManagerUser", "HR");
        manager.Roles.Add(Role.Manager);
        manager.Attributes.Add("Age", 45);
        manager.Attributes.Add("ClearanceLevel", 3);

        var employee = new ExtendedUser(3, "EmployeeUser", "HR");
        employee.Roles.Add(Role.User);
        employee.Attributes.Add("Age", 28);
        employee.Attributes.Add("ClearanceLevel", 1);

        var confidentialHRDoc = new Resource(1, "Document",
            "Employee Records", "ManagerUser", "HR", DateTime.Now, false);
        confidentialHRDoc.Attributes.Add("Sensitivity", "Confidential");
        confidentialHRDoc.Attributes.Add("Version", 1.0);
        confidentialHRDoc.Attributes.Add("ClearanceRequired", 3);

        var publicDoc = new Resource(2, "Document",
            "Company Policy", "AdminUser", "IT", DateTime.Now, true);
        publicDoc.Attributes.Add("Sensitivity", "Public");
        publicDoc.Attributes.Add("Version", 2.0);
        publicDoc.Attributes.Add("ClearanceRequired", 0);
        
        var authService = new Service();

        var clearanceLevelAccessCondition = (User user, Resource resource, Permission action) 
            =>
            {
                if (!(user is ExtendedUser extendedUser))
                    return false;
                if (extendedUser.Attributes.ContainsKey("ClearanceLevel") 
                    && resource.Attributes.ContainsKey("ClearanceRequired"))
                    {
                        int userClearance = Convert.ToInt32(extendedUser.Attributes["ClearanceLevel"]);
                        int requiredClearance = Convert.ToInt32(resource.Attributes["ClearanceRequired"]);
                        return userClearance >= requiredClearance;
                    }
                    return false;
            };
        var clearanceLevelAccessPolicy = new Policy(
            "ClearanceLevelAccess",
            "Access based on clearance level",
            85,
            PolicyEffect.Allow,
            clearanceLevelAccessCondition);
            authService.AddCustomPolicy(clearanceLevelAccessPolicy);

        Console.WriteLine("Authorization Tests:");
        Console.WriteLine(
            $"Admin access to confidential HR doc: {authService.Authorize(admin, confidentialHRDoc, Permission.Read)}");
        Console.WriteLine(
            $"Manager access to confidential HR doc: {authService.Authorize(manager, confidentialHRDoc, Permission.Read)}");
        Console.WriteLine(
            $"Employee access to confidential HR doc: {authService.Authorize(employee, confidentialHRDoc, Permission.Read)}");
        Console.WriteLine(
            $"Employee access to public doc: {authService.Authorize(employee, publicDoc, Permission.Read)}");
        Console.WriteLine(
            $"Employee write to public doc: {authService.Authorize(employee, publicDoc, Permission.Write)}");

        Console.WriteLine("\nContext-based Authorization:");
        var context = new Dictionary<string, object>
        {
            { "TimeOfDay", DateTime.Now.Hour },
            { "IsWeekend", DateTime.Now.DayOfWeek == DayOfWeek.Saturday 
                           || DateTime.Now.DayOfWeek == DayOfWeek.Sunday }
        };

        Console.WriteLine(
            $"Employee read HR doc with context: {authService.AuthorizeWithContext(employee, confidentialHRDoc, Permission.Read, context)}");
    }
}
