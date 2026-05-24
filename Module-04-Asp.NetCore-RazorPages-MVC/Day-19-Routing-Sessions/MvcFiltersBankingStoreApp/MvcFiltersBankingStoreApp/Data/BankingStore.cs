using System;
using System.Collections.Generic;
using MvcFiltersBankingStoreApp.Models;

namespace MvcFiltersBankingStoreApp.Data
{
    public static class BankingStore
    {
        public static List<BankAccount> Accounts { get; } = new List<BankAccount>
        {
            new BankAccount { AccountNumber = "123456", AccountType = "Savings", Balance = 1500.00m, OwnerName = "john" },
            new BankAccount { AccountNumber = "789012", AccountType = "Checking", Balance = 500.00m, OwnerName = "john" },
            new BankAccount { AccountNumber = "999999", AccountType = "Reserve", Balance = 125000.00m, OwnerName = "admin" }
        };

        public static List<Transaction> Transactions { get; } = new List<Transaction>
        {
            new Transaction 
            { 
                Id = 1, 
                AccountNumber = "123456", 
                Type = "Deposit", 
                Amount = 500.00m, 
                Timestamp = DateTime.Now.AddDays(-2), 
                Description = "Initial deposit" 
            },
            new Transaction 
            { 
                Id = 2, 
                AccountNumber = "789012", 
                Type = "Withdrawal", 
                Amount = 50.00m, 
                Timestamp = DateTime.Now.AddDays(-1), 
                Description = "ATM cash withdrawal" 
            }
        };
    }
}
