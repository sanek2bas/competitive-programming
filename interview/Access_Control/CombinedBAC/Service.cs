
public class Service
{
    private readonly RBAC.Service rbacService;
    private readonly ABAC.Service abacService;
    
    public Service(RBAC.Service rbac, ABAC.Service abac)
    {
        rbacService = rbac;
        abacService = abac;
    }

    public bool HasAccess(User user, Resource resource, Permission action)
    {
        // First check basic RBAC permissions
        if (!rbacService.HasPermission(user, action))
            return false;

        // Then apply fine-grained ABAC policies
        return abacService.EvaluateAccess(user, resource, action);
    }
}