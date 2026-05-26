using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day25EFCoreDbFirstSecurity
{
    // Hey diary! This Product model was auto-scaffolded from our existing SmartMartDB table columns.
    // We marked it as a public partial class so that we can easily extend it with our custom C# methods
    // or attributes in separate files without touching this auto-generated code!
    public partial class Product
    {
        // Maps directly to the ProductId primary key column in the database table.
        public int ProductId { get; set; }

        // Maps directly to the ProductName varchar/nvarchar column.
        public string ProductName { get; set; }

        // Maps directly to the Price decimal column.
        public decimal Price { get; set; }

        // Maps directly to the Quantity integer column.
        public int Quantity { get; set; }
    }

    // Hey diary! This is our SmartMartDbContext class.
    // It maps directly out to our pre-built tables without changing anything inside SQL Server.
    // It is reverse-engineered so that EF Core knows exactly how to query our live store tables.
    public class SmartMartDbContext : DbContext
    {
        public SmartMartDbContext()
        {
            // Ready to query our existing catalog!
        }

        public SmartMartDbContext(DbContextOptions<SmartMartDbContext> options) : base(options)
        {
            // Constructor that takes options configuration settings.
        }

        // This DbSet acts as our gateway to query and manage our pre-existing Products table.
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Hey diary! Here is our local fallback connection configuration.
                // We use Windows Authentication to connect to our pre-built SmartMartDB catalog.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SmartMartDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Hey diary! This is where the EF Core reverse-engineering engine maps out the exact columns
            // and key constraints to match what the DBA built inside SQL Server.
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity)
                    .HasDefaultValueSql("((0))");
            });
        }
    }
}
