using Core_EF_Codefirst.Models;

namespace Core_EF_Codefirst.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Emp_DeptContext db;

        //constructor
        public EmployeeRepository(Emp_DeptContext context)
        {
            db = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee UpdateEmployee(Employee empchanges)
        {
            var employee = db.Employees.Attach(empchanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return empchanges;
        }

        public Employee DeleteEmployee(int eid)
        {
            Employee e = db.Employees.Find(eid);
            if (e != null)
            {
                db.Employees.Remove(e);
                db.SaveChanges();
            }
            return e;
        }
    }
}
