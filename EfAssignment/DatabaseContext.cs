using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAssignment
{
    //only for migration
    public class DatabaseContext : DbContext
    {
        // Only for migration
        public DatabaseContext()
        {
        }
        //setting form startup.cs file
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only for purpose of migration....
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"");
            }
        }
    }
}
