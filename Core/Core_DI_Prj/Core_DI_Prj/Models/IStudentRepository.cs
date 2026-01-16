namespace Core_DI_Prj.Models
{
    public interface IStudentRepository
    {
        Student Get(int id);
        List<Student> GetAll();
    }
}
