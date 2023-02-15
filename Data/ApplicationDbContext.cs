using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.NewFolder;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>()
                        .HasOne(s => s.Department) 
                        .WithOne(s => s.Employee)
                        .HasForeignKey<Department>(s => s.Id).IsRequired();

            
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<WebApplication3.NewFolder.EmployeeDetail> EmployeeDetail { get; set; }
    }
}