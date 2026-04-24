using System;
using System.Collections.Generic;

namespace UserRegistrationApi.Controllers
{
    // This is a mock controller for a Web API service
    // In a real project, this would inherit from ControllerBase
    public class UserRegistrationController
    {
        // Mock database of usernames
        private static List<string> existingUsers = new List<string> { "admin", "trainee1" };

        // POST /api/users/register
        public string RegisterUser(string username, string password)
        {
            // 1. Check if username is already taken
            if (existingUsers.Contains(username))
            {
                return "Error: Username already exists.";
            }

            // 2. Check if password is long enough
            if (password.Length < 6)
            {
                return "Error: Password must be at least 6 characters long.";
            }

            // If everything is fine, we "save" the user
            existingUsers.Add(username);

            // Note: On success, this would return a 201 Created status code.
            return "Success: User registered!";
        }
    }
}
