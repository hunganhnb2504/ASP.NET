using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace HRM_ASS.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
