using System;
using Microsoft.EntityFrameworkCore;

namespace Day24EFCoreCodeFirst
{
    // Hey diary! This is our plain Student model class.
    // In the Code-First approach, we write this simple class first, and EF Core
    // will translate it into a SQL Server database table structure for us!
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // Hey diary! This AppDbContext class is our database bridge context.
    // It inherits from EF Core's base DbContext and is responsible for database
    // communications and tracking state alterations on our C# objects.
    public class AppDbContext : DbContext
    {
        // This standard constructor accepts DbContextOptions configuration settings
        // and forwards them down to the parent DbContext via : base(options) logic.
        // This is extremely helpful when we want to inject connection strings or providers!
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Ready to bridge C# and SQL Server!
        }

        // This DbSet represents our Student table. EF Core looks at this property
        // to map our C# Student objects to rows in a SQL database table.
        // Note: The lowercase property name 'students' is intentionally mapped here.
        public DbSet<Student> students { get; set; }
    }
}
