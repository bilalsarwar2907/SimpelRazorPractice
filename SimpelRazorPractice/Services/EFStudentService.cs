using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Models;
namespace SimpelRazorPractice.Services
{
    public class EFStudentService : IStudentCRUD
    {
        private readonly AppDbContext _context;

        public EFStudentService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateStudent(string name)
        {
            var student = new Models.Student
            {                
                StudentName = name
            };

            _context.Students.Add(student);
            _context.SaveChanges();

        }

       public Student? ReadStudentById(int id)
        {
            return _context.Students
                .FirstOrDefault(s => s.StudentId == id);

        }
        public void UpdateStudent(int id, string name,int age, string mail)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.StudentId == id);
            if (student != null )
            {
                student.StudentName = name;
                student.StudentAge = age;
                student.StudentEmail = mail;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent (int id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

    }
}
