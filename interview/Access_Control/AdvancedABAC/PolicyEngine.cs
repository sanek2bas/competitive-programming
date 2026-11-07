
public class PolicyEngine
{
    private readonly Dictionary<string, Policy> policies;

    public PolicyEngine()
    {
        policies = new Dictionary<string, Policy>();

    }

    public void AddDefaultPolicies()
    {
        var adminFullAccessCondition = (User user, Resource resource, Permission action) 
            => user.Roles.Contains(Role.Admin);
        var adminFullAccessPolicy = new Policy(
            "AdminFullAccess",
            "Allow administrators full access to all resources",
            100,
            PolicyEffect.Allow,
            adminFullAccessCondition);
        AddPolicy(adminFullAccessPolicy);

        var denyConfidentialAccessCondition = (User user, Resource resource, Permission action) 
            =>  resource.Attributes.ContainsKey("Sensitivity") 
                && resource.Attributes["Sensitivity"].ToString() == "Confidential" 
                && !user.Roles.Contains(Role.Manager);
        var denyConfidentialAccessPolicy = new Policy(
            "DenyConfidentialAccess",
            "Deny access to confidential resources for non-managers",
            90,
            PolicyEffect.Deny,
            denyConfidentialAccessCondition);
        AddPolicy(denyConfidentialAccessPolicy);

        var departmentAccessCondition = (User user, Resource resource, Permission action) 
            =>  user.Department == resource.Department 
                && (action == Permission.Read || action == Permission.Write);
        var departmentAccessPolicy = new Policy(
            "DepartmentAccess",
            "Allow access to resources in the same department",
            80,
            PolicyEffect.Allow,
            departmentAccessCondition);
        AddPolicy(departmentAccessPolicy);

        var ownerAccessCondition = (User user, Resource resource, Permission action) 
           =>  user.Username == resource.Owner;
        var ownerAccessPolicy = new Policy(
            "OwnerAccess",
            "Allow resource owners full access to their resources",
            70,
            PolicyEffect.Allow,
            ownerAccessCondition);
        AddPolicy(ownerAccessPolicy);

        var timeBasedAccessCondition = (User user, Resource resource, Permission action) 
            =>
            {
                var currentHour = DateTime.Now.Hour;
                return currentHour < 8 || currentHour > 18;
            };
        var timeBasedAccessPolicy = new Policy(
            "TimeBasedAccess",
            "Allow access during business hours only",
            60,
            PolicyEffect.Deny,
            timeBasedAccessCondition);
        AddPolicy(timeBasedAccessPolicy);
    }
    
    public void AddPolicy(Policy policy)
    {
        policies.Add(policy.Name, policy);
    }

    public void RemovePolicy(string policyName)
    {
        if (policies.ContainsKey(policyName))
            policies.Remove(policyName);
    }

    public bool EvaluatePolicies(User user, Resource resource, Permission action)
    {
        var sortedPolicies = policies.Values
                                     .OrderByDescending(p => p.Priority)
                                     .ToList();

        foreach (var policy in sortedPolicies)
        {
            try
            {
                bool result = policy.Condition(user, resource, action);
                
                if (result)
                {
                    if (policy.Effect == PolicyEffect.Deny)
                        return false;
                    if (policy.Effect == PolicyEffect.Allow)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating policy {policy.Name}: {ex.Message}");
                // Continue to next policy or return false based on requirements
            }
        }

        // Default deny if no policy allows
        return false;
    }

}