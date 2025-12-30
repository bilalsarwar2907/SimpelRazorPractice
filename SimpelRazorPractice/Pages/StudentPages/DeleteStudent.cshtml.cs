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
    public class DeleteStudentModel : PageModel
    {
        private readonly IStudentCRUD _studentService;
        public DeleteStudentModel(IStudentCRUD studentService)
        {
            _studentService = studentService;
        }
        [BindProperty]
        public Student Student { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }

        public void OnGet(int studentId)
        {
            StudentId = studentId;
            Student = _studentService.ReadStudentById(StudentId);
        }
        public IActionResult OnPost()
        {
            var student = _studentService.ReadStudentById(StudentId);
            if (student != null)
            _studentService.DeleteStudent(StudentId);
            return RedirectToPage("/Index");
        }
    }
}
