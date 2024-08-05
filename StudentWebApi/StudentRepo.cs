using StudentWebApi.Models;

namespace StudentWebApi
{
    public class StudentRepo : IStudentRepo
    {
        private StudentDbContext _context;
         public StudentRepo(StudentDbContext context) {
            _context = context;

        }
        public Student AddStudent(Student student)
        {
           _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public bool DeleteStudent(int id)
        { var obj = _context.Students.FirstOrDefault(x => x.Id == id);

            _context.Students.Remove(obj);
            _context.SaveChanges(true);
            return true;    
        }

        public Student GetStudent(int id)
        {
            var obj = _context.Students.FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public bool UpdateStudent(int id, Student student)
        {
            var obj = _context.Students.FirstOrDefault(x => x.Id == id);
            obj.Marks = student.Marks;
            _context.SaveChanges();
            return true;
        }
    }
}
