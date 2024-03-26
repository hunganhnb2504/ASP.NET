using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace projectsem3.Data
{
    public class StarSecurityServicesContext : IdentityDbContext<ApplicationsUser>
    {
        public StarSecurityServicesContext(DbContextOptions<StarSecurityServicesContext> options)
          : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
