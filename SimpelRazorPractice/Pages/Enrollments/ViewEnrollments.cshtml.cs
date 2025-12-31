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
    public class ViewEnrollmentsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IEnrollmentService _service;
        public ViewEnrollmentsModel(AppDbContext context, IEnrollmentService service)
        {
            _context = context;
            _service = service;
        }
        [BindProperty]
        public List <StudentToCourse> Enrollments { get; set; } = new List<StudentToCourse>();
        public async Task  OnGetAsync()
        {
            Enrollments =await _context.StudentToCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToListAsync();
        }
    }
}
