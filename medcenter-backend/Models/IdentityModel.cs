using medcenter_backend.Models;

public class AplicationRole : IdentityRole
{
    public AplicationRole() : base() { }
    public AplicationRole(string roleName) : base(roleName) { }

}
public class AplicationDbContext : IdentityDbContext<AplicationUser>
{ 
    public AplicationDbContext()
        : base ("DefaultConnection", throwIfV1Schema : false)
    { }
}