namespace SimpelRazorPractice.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;

        private int _studentAge;
        public int StudentAge
        {
            get => _studentAge;
            set
            {
                if (value < 0 || value > 60)
                    throw new ArgumentOutOfRangeException(nameof(StudentAge), "Age must be between 0 and 60.");
                _studentAge = value;
            }
        }


        public ICollection<StudentToCourse> StudentToCourses { get; set; }
    }
}
