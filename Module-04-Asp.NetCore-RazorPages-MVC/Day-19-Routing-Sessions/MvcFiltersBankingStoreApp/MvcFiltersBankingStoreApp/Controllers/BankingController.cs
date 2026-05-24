using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcFiltersBankingStoreApp.Data;
using MvcFiltersBankingStoreApp.Filters;
using MvcFiltersBankingStoreApp.Models;

namespace MvcFiltersBankingStoreApp.Controllers
{
    [TypeFilter(typeof(SimpleAuthenticationFilter))]
    public class BankingController : Controller
    {
        // Route: /Banking/Accounts
        public IActionResult Accounts()
        {
            var accounts = BankingStore.Accounts;
            return View(accounts);
        }

        // Route: /Banking/Transactions
        public IActionResult Transactions()
        {
            var transactions = BankingStore.Transactions;
            return View(transactions);
        }

        // Route: /Banking/Transfer (GET)
        public IActionResult Transfer()
        {
            return View();
        }

        // Route: /Banking/Transfer (POST)
        [HttpPost]
        [TypeFilter(typeof(UserActionLoggingFilter))]
        public IActionResult Transfer(string fromAccount, string toAccount, decimal amount)
        {
            var source = BankingStore.Accounts.FirstOrDefault(a => a.AccountNumber == fromAccount);
            var target = BankingStore.Accounts.FirstOrDefault(a => a.AccountNumber == toAccount);

            if (source == null || target == null)
            {
                ViewBag.Error = "Invalid source or destination account number.";
                return View();
            }

            if (source.Balance < amount)
            {
                ViewBag.Error = "Insufficient funds in the source account.";
                return View();
            }

            if (amount <= 0)
            {
                ViewBag.Error = "Transfer amount must be positive.";
                return View();
            }

            // Perform transfer
            source.Balance -= amount;
            target.Balance += amount;

            // Log ledger entry
            var transactionId = BankingStore.Transactions.Count + 1;
            BankingStore.Transactions.Add(new Transaction
            {
                Id = transactionId,
                AccountNumber = fromAccount,
                Type = "Transfer",
                Amount = amount,
                Timestamp = DateTime.Now,
                Description = $"Transferred to {toAccount}"
            });

            ViewBag.Success = $"Successfully transferred ${amount:F2} from {fromAccount} to {toAccount}.";
            return View();
        }
    }
}
