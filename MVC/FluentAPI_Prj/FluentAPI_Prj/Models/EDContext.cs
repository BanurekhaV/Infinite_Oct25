using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FluentAPI_Prj.Models
{
    public class EDContext : DbContext
    {
        public EDContext() : base("name=edmodel"){ }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        //1. Default names along with the entityname
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().MapToStoredProcedures();
        //}

        //2. user names to stored procedure
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures(sp => sp.Insert(
                s => s.HasName("InsertEmployeeProc", "dbo")).Update(
                s => s.HasName("UpdateemployeeProc", "dbo")).Delete(
                s => s.HasName("DeleteEmployeeProc", "dbo")));
        }

        //3. create stored procedures for all entities
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        //}

        //4. with parameter collection
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().MapToStoredProcedures(sp => sp.Insert(
        //        s => s.HasName("AddEmployee").Parameter(pm => pm.Name, "Name").
        //        Parameter(pm => pm.Salary, "Salary")).Delete(
        //        s => s.HasName("DeleteEmployee").Parameter(pm => pm.Id, "Id")));
        //}
    }
}