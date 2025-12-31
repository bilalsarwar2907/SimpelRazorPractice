using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;
using SimpelRazorPractice.ViewModels;
using SimpelRazorPractice.Pages.Enrollments;
using System.Threading.Tasks;


namespace SimpelRazorPractice.Pages.StudentPages
{
    public class StudentIndexModel : PageModel
    {
        private readonly IStudentCRUD _studentService;
        private readonly AppDbContext _context;
        public StudentIndexModel(AppDbContext context,IStudentCRUD studentService)
        {
            _studentService = studentService;
            _context = context;
        }
      
        public Models.Student Student { get; set; }
        public List<Models.Student> Students { get; set; } = new List<Models.Student>();
      
        [BindProperty (SupportsGet = true)]
        public int StudentId { get; set; }
       
       public List<StudentToCourse> Enrollments { get; set; } = new List<StudentToCourse>();


        public IActionResult OnGet()
        {
            Enrollments = _context.StudentToCourses
                .Include(sc => sc.Course)
                .Where(sc => sc.StudentId == StudentId)
                .ToList();
            Student = _studentService.ReadStudentById(StudentId);

            if (Student == null)
                return NotFound();

            return Page();
        }



    }
}
