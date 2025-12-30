namespace SimpelRazorPractice.Models
{
    public class Teacher
    {
        public string TeacherName { get; set; } = string.Empty;
        public int TeacherId { get; set; }

        public ICollection<TeacherToCourse> TeacherToCourses { get; set; } = new List<TeacherToCourse>();

    }
}
