namespace MvcFiltersBankingStoreApp.Models
{
    public class UserContext
    {
        public bool IsLoggedIn { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
