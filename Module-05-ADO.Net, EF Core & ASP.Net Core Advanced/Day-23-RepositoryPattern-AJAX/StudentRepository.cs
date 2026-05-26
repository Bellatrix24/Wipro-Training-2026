using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Day23RepositoryPatternAJAX
{
    // Hey diary! This is the actual implementation of our IStudentRepository.
    // It handles the real work of talking to SQL Server through our EF Core CollegeDbContext.
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDbContext _context;

        // We inject the CollegeDbContext through the constructor.
        // This lets our repository share the same database session context.
        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }

        // GetAllAsync fetches all records in the background.
        // We use 'async' on the method and 'await' before ToListAsync() so the C# web server 
        // doesn't block or freeze while the database gathers the student records.
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            // Hey diary! ToListAsync() is EF Core's built-in async way to retrieve all rows.
            return await _context.Students.ToListAsync();
        }

        // GetByIdAsync gets a single student using their ID.
        // Using 'await' tells our thread to pause here and wait for the database, 
        // allowing the thread pool to work on other client requests in the meantime.
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        // AddAsync adds a student to the EF context tracker in the background.
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        // SaveAsync writes all pending changes down into the SQL Server database.
        public async Task SaveAsync()
        {
            // Hey diary! SaveChangesAsync() translates all our C# object changes 
            // into actual SQL INSERT, UPDATE, or DELETE commands and runs them in one transaction.
            await _context.SaveChangesAsync();
        }
    }

    // Dummy definitions to avoid compiler complaints during standalone review:
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CollegeDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WiproCollegeDb;Trusted_Connection=True;");
        }
    }
}
