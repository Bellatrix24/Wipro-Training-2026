using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day22EFCoreIntro
{
    // Hey diary! This class represents a table inside our database.
    // EF Core takes this plain C# class and translates it into a SQL table structure.
    public class Student
    {
        // [Key] tells EF Core that this property will act as our Primary Key in the SQL database.
        // It will automatically become an Identity column (auto-incrementing) in SQL Server.
        [Key]
        public int Id { get; set; }

        // [Required] acts like a NOT NULL constraint on our SQL column.
        // EF Core will enforce that name is mandatory before saving any record!
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    // This DbContext is like the brain of our database operations.
    // It manages the connection to the server, tracks changes, and lets us query and save data.
    public class CollegeDbContext : DbContext
    {
        // This DbSet tells EF Core to treat the C# class as an active database table.
        // We will interact with this 'Students' property to run queries and insert rows!
        public DbSet<Student> Students { get; set; }

        // OnConfiguring is a special method we override to tell EF Core where to find our database.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Hey diary! Here we tell EF Core to use SQL Server and pass in our connection string.
            // It manages opening and closing this pipeline automatically for us in the background.
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=WiproCollegeDb;Trusted_Connection=True;TrustServerCertificate=True;";
            
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
