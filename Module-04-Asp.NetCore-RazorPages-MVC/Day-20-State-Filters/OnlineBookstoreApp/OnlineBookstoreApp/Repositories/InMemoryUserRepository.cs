using System;
using System.Collections.Generic;
using System.Linq;
using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<UserAccount> _users = new List<UserAccount>
        {
            new UserAccount { Username = "admin", Password = "admin123", Role = "Admin" },
            new UserAccount { Username = "customer", Password = "customer123", Role = "Customer" }
        };

        public UserAccount? GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(UserAccount account)
        {
            if (GetByUsername(account.Username) == null)
            {
                _users.Add(account);
            }
        }
    }
}
