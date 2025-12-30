using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Data;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;
using SimpelRazorPractice.ViewModels;
using System.Threading.Tasks;
namespace SimpelRazorPractice.Pages
{
    public class CreateCourseModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateCourseModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Course Course { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public void OnGet()
        {
            Courses =  _context.Courses.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
