using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SecureShoppingPlatform.Models;

namespace SecureShoppingPlatform.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            await CreateUserAsync(userManager, "admin@example.com", "Admin User", "Admin");
            await CreateUserAsync(userManager, "customer@example.com", "Customer User", "Customer");
        }

        private static async Task CreateUserAsync(UserManager<ApplicationUser> userManager, string email, string fullName, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FullName = fullName,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Password@123");
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
