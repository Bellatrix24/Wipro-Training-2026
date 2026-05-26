using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day23RepositoryPatternAJAX
{
    // Hey diary! This interface acts like a contract for our data access tasks.
    // It lists exactly what operations we can do with our Student records, without
    // worrying about the actual SQL or EF database context commands here.
    public interface IStudentRepository
    {
        // Fetches all students asynchronously from the database.
        // Task represents a background job that will eventually return the list.
        Task<IEnumerable<Student>> GetAllAsync();

        // Fetches a single student by their ID asynchronously.
        Task<Student> GetByIdAsync(int id);

        // Adds a new student record to our tracking set asynchronously.
        Task AddAsync(Student student);

        // Saves all changes made in our database context change tracker.
        // This is where the actual SQL commands get executed inside the database!
        Task SaveAsync();
    }
}
