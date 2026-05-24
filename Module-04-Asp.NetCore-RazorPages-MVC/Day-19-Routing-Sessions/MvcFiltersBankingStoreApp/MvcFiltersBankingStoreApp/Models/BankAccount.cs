namespace MvcFiltersBankingStoreApp.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string OwnerName { get; set; } = string.Empty;
    }
}
