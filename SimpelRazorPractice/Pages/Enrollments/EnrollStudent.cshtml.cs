using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;
using SimpelRazorPractice.ViewModels;
using System.Threading.Tasks;


namespace SimpelRazorPractice.Pages.Enrollments
{
    public class EnrollStudentModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IEnrollmentService _service;
        public EnrollStudentModel(AppDbContext context, IEnrollmentService service)
        {
            _context = context;
            _service = service;
        }
        [BindProperty]
        public int StudentId { get; set; }
        [BindProperty]
        public int CourseId { get; set; }

        [BindProperty]
        public string Message { get; set; }

        public bool IsSuccess { get; set; } = false;

        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public void OnGet()
        {
            Students = _context.Students.ToList();
            Courses = _context.Courses.ToList();
        }
        public void OnPost()
        {
            var enrollment = new StudentToCourse
            {
                StudentId = StudentId,
                CourseId = CourseId
            };

            _context.StudentToCourses.Add(enrollment);
            _context.SaveChanges();

            IsSuccess = true;

                        Message = "Student enrolled successfully.";

            Students = _context.Students.ToList();
            Courses = _context.Courses.ToList();
        }
    }
}
