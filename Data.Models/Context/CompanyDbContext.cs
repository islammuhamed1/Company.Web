using Company.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Company.Data.Context
{
    public class CompanyDbContext : DbContext
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


        public DbSet<DepartmentViewModel> Departments { get; set; }
        public DbSet<EmployeeViewModel> Employees { get; set; }
    }
}
