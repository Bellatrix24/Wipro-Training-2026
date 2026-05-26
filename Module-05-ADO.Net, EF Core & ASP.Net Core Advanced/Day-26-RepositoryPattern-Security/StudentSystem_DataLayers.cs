using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day26RepositoryPatternSecurity
{
    // Hey diary! This is our plain Student model class.
    // We use [Key] to designate our Primary Key column and [Required] to enforce NOT NULL database constraints.
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Course { get; set; }

        public int Age { get; set; }
    }

    // Hey diary! This custom context class acts as our bridge responsible for database communications
    // and tracking state alterations on C# objects.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Ready to bridge C# and SQL Server!
        }

        // Represents our Students table in the database catalog.
        public DbSet<Student> Students { get; set; }
    }

    // Hey diary! This interface acts like a contract for our data access tasks.
    // It keeps our presentation controller completely lightweight and decoupled from EF Core itself.
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student s);
        void UpdateStudent(Student s);
        void DeleteStudent(int id);
        void Save();
    }

    // Hey diary! Here is the concrete repository implementation.
    // We inject our DbContext through the constructor and use standard EF Core calls.
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        // Scoped constructor injection of our database session bridge context.
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        // Hey diary! Let's write the delete logic safely.
        // We first find the student object target by id, and verify it isn't null
        // before calling the internal tracker .Remove() method. This keeps us safe from null crashes!
        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
