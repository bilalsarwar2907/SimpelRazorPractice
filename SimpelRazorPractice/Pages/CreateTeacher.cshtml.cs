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
    public class CreateTeacherModel : PageModel
    {
        private readonly AppDbContext _context;
        public CreateTeacherModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Teacher Teacher { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public void OnGet()
        {
            Teachers = _context.Teachers.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Teachers.Add(Teacher);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
