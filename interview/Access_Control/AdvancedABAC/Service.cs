public class Service
{
    private readonly PolicyEngine policyEngine;
    
    public Service()
    {
        policyEngine = new PolicyEngine();
        policyEngine.AddDefaultPolicies();
    }

    public bool Authorize(User user, Resource resource, Permission action)
    {
        return policyEngine.EvaluatePolicies(user, resource, action);
    }

    public bool AuthorizeWithContext(
        User user, Resource resource, Permission action, Dictionary<string, object> context)
    {
        var mergedResource = new Resource(
            resource.Id,
            resource.Type,
            resource.Name,
            resource.Owner,
            resource.Department,
            resource.CreatedDate,
            resource.IsPublic);
        foreach (var attributeKeyValuePair in resource.Attributes)
        {
            mergedResource.Attributes.Add(attributeKeyValuePair.Key, attributeKeyValuePair.Value);
        }

        foreach (var kvp in context)
        {
            mergedResource.Attributes[kvp.Key] = kvp.Value;
        }

        return policyEngine.EvaluatePolicies(user, mergedResource, action);
    }

        public void AddCustomPolicy(Policy policy)
        {
            policyEngine.AddPolicy(policy);
        }
}