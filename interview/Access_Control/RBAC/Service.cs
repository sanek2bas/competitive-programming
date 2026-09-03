public class Service
{
    private readonly Dictionary<Role, List<Permission>> rolePermissions;
    
    public Service()
    {
        rolePermissions = new Dictionary<Role, List<Permission>>();
        InitializeRoles();
    }

    public bool HasPermission(User user, Permission requiredPermission)
    {
        foreach (var role in user.Roles)
        {
            if (rolePermissions.ContainsKey(role) 
                && rolePermissions[role].Contains(requiredPermission))
                return true;
        }
        return false;
    }

    public bool HasAnyPermission(User user, List<Permission> requiredPermissions)
    {
        return requiredPermissions.Any(p => HasPermission(user, p));
    }

    public bool HasAllPermissions(User user, List<Permission> requiredPermissions)
    {
        return requiredPermissions.All(p => HasPermission(user, p));
    }

    public void AddRolePermission(Role role, Permission permission)
    {
        if (!rolePermissions.ContainsKey(role))
            rolePermissions[role] = new List<Permission>();
        
        if (!rolePermissions[role].Contains(permission))
            rolePermissions[role].Add(permission);
    }

    public void RemoveRolePermission(Role role, Permission permission)
    {
        if (rolePermissions.ContainsKey(role))
            rolePermissions[role].Remove(permission);
    }

    private void InitializeRoles()
    {
        rolePermissions[Role.Admin] = new List<Permission> 
        { 
            Permission.Read, 
            Permission.Write, 
            Permission.Delete,
            Permission.Execute
        };
        
        rolePermissions[Role.Manager] = new List<Permission> 
        { 
            Permission.Read, 
            Permission.Write, 
            Permission.Delete 
        };

        rolePermissions[Role.User] = new List<Permission> 
        { 
            Permission.Read, 
            Permission.Write 
        };

        rolePermissions[Role.Guest] = new List<Permission> 
        { 
           Permission.Read 
        };
    }
}