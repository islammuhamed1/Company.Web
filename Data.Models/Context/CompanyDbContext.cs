using Company.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Company.Data.Context
{
    public class CompanyDbContext : IdentityDbContext<IdentityUser>
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
