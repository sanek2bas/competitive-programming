public class Service()
{
    public bool EvaluateAccess(User user, Resource resource, string action)
    {
        // Policy 1: Users can only read public resources
        if (action == "Read" && resource.IsPublic)
            return true;

        // Policy 2: Users can read, write, delete resources in their department
        if (user.Department == resource.Department 
            && new[] { "Read", "Write", "Delete" }.Contains(action))
            return true;

        // Policy 3: Only resource owners can delete their resources
        if (action == "Delete" 
            && user.Username == resource.Owner)
            return true;

        // Policy 4: Users can create resources in their department
        if (action == "Create" 
            && user.Department == resource.Department)
            return true;

        // Policy 5: Users can execute resources if they have Executor role attribute
        if (action == "Execute" 
            && user.Roles.Contains("Executor"))
            return true;

        // Policy 6: Department managers can access all resources in their department
        if (user.Roles.Contains("Manager") && user.Department == resource.Department)
            return true;

        // Policy 7: Admins have all access
        if (user.Roles.Contains("Admin"))
            return true;

        return false;
    }

    public bool EvaluateComplexAccess(ExtendedUser user, Resource resource, string action, DateTime currentTime, bool isWeekend = false)
    {
        // Time-based access control
        if (currentTime.Hour < 9 || currentTime.Hour > 17)
        {
            // Only admins can access after hours
            return user.Roles.Contains("Admin");
        }

        // Weekend access restrictions
        if (isWeekend && 
            !user.Roles.Contains("Admin"))
            return false;

        // Resource sensitivity check
        if (resource.Attributes.ContainsKey("Sensitivity"))
        {
            string sensitivity = resource.Attributes["Sensitivity"].ToString();
            if (sensitivity == "Confidential" && !user.Roles.Contains("Manager"))
                return false;
        }

        // Age restriction for certain resources
        if (resource.Attributes.ContainsKey("AgeRestriction"))
        {
            int ageRestriction = Convert.ToInt32(resource.Attributes["AgeRestriction"]);
            if (user.Attributes.ContainsKey("Age"))
            {
                int userAge = Convert.ToInt32(user.Attributes["Age"]);
                if (userAge < ageRestriction)
                    return false;
            }
        }

        // Apply standard policies
        return EvaluateAccess(user, resource, action);
    }
}