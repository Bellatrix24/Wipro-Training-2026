using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecureTaskManagementPlatform.Models;

namespace SecureTaskManagementPlatform.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure roles
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Admin
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Admin Principal",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Password@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    // Add Claims
                    await userManager.AddClaimAsync(adminUser, new Claim("CanEditTask", "true"));
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
                    FullName = "Regular Employee",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(regularUser, "Password@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(regularUser, "User");
                    // Add Claims - Regular user is also granted editing permission
                    await userManager.AddClaimAsync(regularUser, new Claim("CanEditTask", "true"));
                }
            }

            // Seed a limited user (to show access denial for claim)
            var limitedEmail = "limited@example.com";
            var limitedUser = await userManager.FindByEmailAsync(limitedEmail);
            if (limitedUser == null)
            {
                limitedUser = new ApplicationUser
                {
                    UserName = limitedEmail,
                    Email = limitedEmail,
                    FullName = "Limited Reader",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(limitedUser, "Password@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(limitedUser, "User");
                    // DO NOT add CanEditTask claim for this user to demonstrate claim check failure
                }
            }

            // Seed Sample Tasks and Comments
            if (!await dbContext.Tasks.AnyAsync())
            {
                var task1 = new TaskItem
                {
                    Title = "Verify Input Sanitization",
                    Description = "Make sure all forms prevent HTML/Script tags to prevent stored XSS.",
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(3),
                    UserId = regularUser.Id
                };

                var task2 = new TaskItem
                {
                    Title = "Review Claims Policy",
                    Description = "Confirm that only users with the CanEditTask claim can access edit actions.",
                    IsCompleted = true,
                    DueDate = DateTime.Now.AddDays(1),
                    UserId = adminUser.Id
                };

                dbContext.Tasks.AddRange(task1, task2);
                await dbContext.SaveChangesAsync();

                var comment = new TaskComment
                {
                    Content = "Initial review shows that Razor automatically encodes all outputs safely.",
                    CreatedAt = DateTime.Now,
                    TaskId = task1.TaskId,
                    UserId = adminUser.Id
                };

                dbContext.Comments.Add(comment);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
