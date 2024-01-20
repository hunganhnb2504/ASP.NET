using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ass.Models;

namespace Ass.Data
{
    public class AssContext : DbContext
    {
        public AssContext (DbContextOptions<AssContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public object Departments { get; internal set; }
        public IEnumerable<object> Employees { get; internal set; }
    }
}
