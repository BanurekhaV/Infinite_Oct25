using Core_EF_Codefirst.Models;

namespace Core_EF_Codefirst.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee emplchanges);
        Employee DeleteEmployee(int eid);
    }
}
