using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecureDatabaseSecurityPortal.Models;
using SecureDatabaseSecurityPortal.Services;

namespace SecureDatabaseSecurityPortal.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var hmacService = serviceProvider.GetRequiredService<HmacService>();

            // Ensure roles
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Admin User
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Admin Auditor",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "Password@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed Regular User
            var userEmail = "user@example.com";
            var regularUser = await userManager.FindByEmailAsync(userEmail);
            if (regularUser == null)
            {
                regularUser = new ApplicationUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                    FullName = "Standard Clerk",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(regularUser, "Password@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                }
            }

            // Seed Sample Secure Customer Records
            if (!await context.CustomerRecords.AnyAsync())
            {
                var plainTaxId1 = "123-45-6789";
                var encryptedTaxId1 = hmacService.Encrypt(plainTaxId1);
                var hmacTaxId1 = hmacService.ComputeHmac(plainTaxId1);

                var plainTaxId2 = "987-65-4321";
                var encryptedTaxId2 = hmacService.Encrypt(plainTaxId2);
                var hmacTaxId2 = hmacService.ComputeHmac(plainTaxId2);

                context.CustomerRecords.AddRange(
                    new CustomerRecord
                    {
                        FullName = "Alice Johnson",
                        Email = "alice@example.com",
                        PhoneNumber = "555-0199",
                        EncryptedTaxId = encryptedTaxId1,
                        TaxIdHmac = hmacTaxId1
                    },
                    new CustomerRecord
                    {
                        FullName = "Bob Smith",
                        Email = "bob@example.com",
                        PhoneNumber = "555-0188",
                        EncryptedTaxId = encryptedTaxId2,
                        TaxIdHmac = hmacTaxId2
                    }
                );

                await context.SaveChangesAsync();
            }

            // Seed Audit Logs
            if (!await context.AuditLogs.AnyAsync())
            {
                context.AuditLogs.AddRange(
                    new AuditLog
                    {
                        UserEmail = "System",
                        Action = "Seeding",
                        Details = "System seeded initial database records securely.",
                        Timestamp = DateTime.Now,
                        IsSuspicious = false
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
