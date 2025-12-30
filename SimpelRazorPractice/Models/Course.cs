namespace SimpelRazorPractice.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public ICollection<StudentToCourse> StudentToCourses { get; set; } = new List<StudentToCourse>();
        public ICollection<TeacherToCourse> TeacherToCourses { get; set; } = new List<TeacherToCourse>();
    }
}
