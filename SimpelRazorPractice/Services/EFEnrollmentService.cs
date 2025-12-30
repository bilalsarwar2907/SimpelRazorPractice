using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Data;

namespace SimpelRazorPractice.Services
{
    public class EFEnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EFEnrollmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task EnrollStudentInCourse(int studentId, int courseId)
        {
            var enrollment = new StudentToCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };


            _context.StudentToCourses.Add(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
