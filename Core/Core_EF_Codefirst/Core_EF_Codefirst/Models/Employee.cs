using System.ComponentModel;

namespace Core_EF_Codefirst.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; } = null;
        public string? Position { get; set; }

        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }   

        public Department ? Department { get; set; }
    }
}
