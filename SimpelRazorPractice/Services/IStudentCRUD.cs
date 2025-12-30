using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Models;
using SimpelRazorPractice.Services;
namespace SimpelRazorPractice.Services
{
    public interface IStudentCRUD
    {
         void CreateStudent(string name);
        Student? ReadStudentById(int id);
        void UpdateStudent(int id,string name,int age,string mail);
        void DeleteStudent(int id);
    }
}
