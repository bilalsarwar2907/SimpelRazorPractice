using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Services;
using SimpelRazorPractice.ViewModels;
using SimpelRazorPractice.Models;
using System.Threading.Tasks;

namespace SimpelRazorPractice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IEnrollmentService _service;

        public StudentEnrollmentVM? ViewModel { get; set; }
        public IndexModel(AppDbContext context, IEnrollmentService service)
        {
            _context = context;
            _service = service;
        }
        public List<Student> Students { get; set; } = new List<Models.Student>();
        public List<Course> Courses { get; set; } = new List<Models.Course>();
        public List<Teacher> Teachers { get; set; } = new List<Models.Teacher>();

        public async Task OnGetAsync()
        {
            bool exists = _context.Database.CanConnect();
            Console.WriteLine("DATABASE EXISTS = " + exists);

            var countS = await _context.Students.CountAsync();
            Console.WriteLine("STUDENT COUNT = " + countS);

            var countC = await _context.Courses.CountAsync(); 
            Console.WriteLine("Course Count = " + countC);

            if (!await _context.Students.AnyAsync())
            {
                var studentName = new Models.Student
                {
                    StudentName = "Test Student"
                };
                _context.Students.Add(studentName);
                await _context.SaveChangesAsync();
            }

            Students = await _context.Students.ToListAsync();

            if (!await _context.Courses.AnyAsync())
            {
                var course = new Models.Course
                {
                    CourseTitle = "Test Course"
                };
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
            }
            Courses = await _context.Courses.ToListAsync();

            if (!await _context.Teachers.AnyAsync())
            {
                var teacher = new Models.Teacher
                {
                    TeacherName = "Test Teacher"
                };
                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
            }
            Teachers = await _context.Teachers.ToListAsync();

            // Get enrollments using the service

            // Or if you want to use DbContext directly:
            //var student = await _context.Students
            //    .Include(s => s.StudentToCourses)
            //    .ThenInclude(stc => stc.Course)
            //    .FirstOrDefaultAsync();

            //if (student != null)
            //{
            //    ViewModel = new StudentEnrollmentVM
            //    {
            //        StudentId = student.StudentId,
            //        StudentName = student.StudentName, // Your property is StudentName, not Name
            //        // Note: Your StudentEnrollmentVM doesn't have a Courses property
            //        // You might need to adjust this
            //    };
            //}
        }
    }
}