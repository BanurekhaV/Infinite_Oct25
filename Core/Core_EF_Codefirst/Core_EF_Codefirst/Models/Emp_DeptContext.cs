using Microsoft.EntityFrameworkCore;

namespace Core_EF_Codefirst.Models
{
    public class Emp_DeptContext : DbContext
    {
        public Emp_DeptContext(DbContextOptions<Emp_DeptContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // base.OnModelCreating(modelBuilder);
        }

        //2. adding our domain classes
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
