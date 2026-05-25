using OnlineBookstoreApp.Models;

namespace OnlineBookstoreApp.Repositories
{
    public interface IUserRepository
    {
        UserAccount? GetByUsername(string username);
        void Add(UserAccount account);
    }
}
