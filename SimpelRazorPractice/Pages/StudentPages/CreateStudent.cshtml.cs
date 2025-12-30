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
    public class CreateStudentModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IStudentCRUD _studentService;

        public CreateStudentModel(AppDbContext context, IStudentCRUD studentService)
        {
            _context = context;
            _studentService = studentService;
        }
        [BindProperty]
        public Student Student { get; set; }
        [BindProperty]
        public int StudentId { get; set; }

        public Student? FoundStudent { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public void OnGet()
        {
            Students =  _context.Students.ToList();
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    _context.Students.Add(Student);
        //    await _context.SaveChangesAsync();
        //    return RedirectToPage("Index");

        //}
        public async Task<IActionResult> OnPostCreateAsync()
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostFindStudent()
        {
            FoundStudent = _studentService.ReadStudentById(StudentId);
            if (FoundStudent == null)
            {
                return NotFound();
            }
            return Page();
        }
       
    }
}
