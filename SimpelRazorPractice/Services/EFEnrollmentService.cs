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
        public async Task<bool> EnrollStudentInCourse(int studentId, int courseId)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.StudentId == studentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.CourseId == courseId);
            if (!studentExists || !courseExists)
                return false;
        
            var alreadyEnrolled = await _context.StudentToCourses
                .AnyAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (alreadyEnrolled)
                return false;


            var enrollment = new StudentToCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };


            _context.StudentToCourses.Add(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
