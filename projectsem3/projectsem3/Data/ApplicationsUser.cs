using Microsoft.AspNetCore.Identity;

namespace projectsem3.Data
{
    public class ApplicationsUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
