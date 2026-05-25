using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SecureShoppingPlatform.Models;

namespace SecureShoppingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
            builder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(10,2)");
            builder.Entity<OrderItem>().Property(i => i.UnitPrice).HasColumnType("decimal(10,2)");

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItem>()
                .HasOne(i => i.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(i => i.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop Bag", Description = "Simple padded laptop bag.", Price = 799, Stock = 20 },
                new Product { ProductId = 2, Name = "Wireless Mouse", Description = "Basic wireless mouse.", Price = 499, Stock = 35 },
                new Product { ProductId = 3, Name = "Keyboard", Description = "USB keyboard for daily use.", Price = 699, Stock = 25 },
                new Product { ProductId = 4, Name = "Headphones", Description = "Wired headphones with mic.", Price = 599, Stock = 30 }
            );
        }
    }
}
