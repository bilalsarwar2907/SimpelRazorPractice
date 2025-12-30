using Microsoft.EntityFrameworkCore;
using SimpelRazorPractice.Models;

namespace SimpelRazorPractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // These create database tables for each model
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentToCourse> StudentToCourses { get; set; }
        public DbSet<TeacherToCourse> TeacherToCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // -------------------------------
            // STUDENT ↔ COURSE (Many-to-Many)
            // -------------------------------

            // The join table uses StudentId + CourseId as its combined primary key
            modelBuilder.Entity<StudentToCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Each StudentToCourse row belongs to ONE Student
            // One Student can have MANY StudentToCourse rows
            // StudentId is the foreign key that links them
            modelBuilder.Entity<StudentToCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentToCourses)
                .HasForeignKey(sc => sc.StudentId);

            // Each StudentToCourse row belongs to ONE Course
            // One Course can have MANY StudentToCourse rows
            // CourseId is the foreign key that links them
            modelBuilder.Entity<StudentToCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentToCourses)
                .HasForeignKey(sc => sc.CourseId);


            // -------------------------------
            // TEACHER ↔ COURSE (Many-to-Many)
            // -------------------------------

            // The join table uses TeacherId + CourseId as its combined primary key
            modelBuilder.Entity<TeacherToCourse>()
                .HasKey(tc => new { tc.TeacherId, tc.CourseId });

            // Each TeacherToCourse row belongs to ONE Teacher
            // One Teacher can have MANY TeacherToCourse rows
            // TeacherId is the foreign key that links them
            modelBuilder.Entity<TeacherToCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeacherToCourses)
                .HasForeignKey(tc => tc.TeacherId);

            // Each TeacherToCourse row belongs to ONE Course
            // One Course can have MANY TeacherToCourse rows
            // CourseId is the foreign key that links them
            modelBuilder.Entity<TeacherToCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherToCourses)
                .HasForeignKey(tc => tc.CourseId);
        }

        // Add your DbSet properties here
        // Example: public DbSet<Product> Products { get; set; }
    }
}