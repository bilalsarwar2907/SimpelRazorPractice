using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;
using SimpelRazorPractice.ViewModels;
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
        [BindProperty]
        public Models.Student Student { get; set; }
        public List<Models.Student> Students { get; set; } = new List<Models.Student>();
      
        [BindProperty (SupportsGet = true)]
        public int StudentId { get; set; }

        public IActionResult OnGet()
        {
            Student = _studentService.ReadStudentById(StudentId);

            if (Student == null)
                return NotFound();

            return Page();
        }



    }
}
