using StudentWebApi.Models;

namespace StudentWebApi
{
    public interface IStudentRepo
    {
        public List<Student> GetStudents();
        public Student GetStudent(int id);
        public Student AddStudent(Student student);
        public bool     UpdateStudent(int id,Student student);
public bool DeleteStudent(int id);  
    }

}
