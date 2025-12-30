using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpelRazorPractice.Services;

namespace SimpelRazorPractice.Pages.StudentPages
{
    public class EditStudentModel : PageModel
    {
        private readonly IStudentCRUD _studentService;

        public EditStudentModel(IStudentCRUD studentService)
        {
            _studentService = studentService;
        }
        [BindProperty]
        public Models.Student Student { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }

      
        public void OnGet(int s)
        {
            StudentId = s;

            Student = _studentService.ReadStudentById(s);
        }
        public IActionResult OnPostUpdateStudent()
        {
            var student = _studentService.ReadStudentById(StudentId);
            if (student != null)
            _studentService.UpdateStudent(StudentId, Student.StudentName, Student.StudentAge,Student.StudentEmail);
            return RedirectToPage("/Index");
        }
    }
}
