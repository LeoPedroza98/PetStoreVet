using Microsoft.AspNetCore.Identity;

namespace PetStore.VeterinarioAPI.Identity;

public class Role : IdentityRole
{
    public Role(string roleName) : base(roleName)
    {
    }

    protected Role()
    {

    }
}