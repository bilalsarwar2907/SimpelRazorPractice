using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;

namespace SimpelRazorPractice.Services
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollStudentInCourse(int studentId, int courseId);
    }
}