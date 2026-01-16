namespace Core_DI_Prj.Models
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> StudentData()
        {
            return new List<Student>() {
                new Student{StudentId=1, Name="Bob", Branch="CSE",Gender="Male"},
                 new Student{StudentId=2, Name="Pamela", Branch="EEE",Gender="Female"},
                  new Student{StudentId=3, Name="Dwight", Branch="IT",Gender="Male"},
                  new Student{StudentId=4, Name="Alex", Branch="ETC",Gender="Male"},
            };
        }

        public Student Get(int id)
        {
            return StudentData().FirstOrDefault(s => s.StudentId == id) ?? new Student();
        }

        public List<Student> GetAll()
        {
            return StudentData();            
        }
    }
}
