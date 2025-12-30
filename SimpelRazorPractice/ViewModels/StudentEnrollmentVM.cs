namespace SimpelRazorPractice.ViewModels
{
    public class StudentEnrollmentVM
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
    }
}
