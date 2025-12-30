using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;

namespace SimpelRazorPractice.Services
{
    public interface IEnrollmentService
    {
        Task EnrollStudentInCourse(int studentId, int courseId);

    }
}
