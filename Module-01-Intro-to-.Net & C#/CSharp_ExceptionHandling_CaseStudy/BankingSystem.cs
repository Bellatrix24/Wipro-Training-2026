using System;

namespace BankingSystemApp
{
    // Custom Exceptions
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    // Bank Account Base Structure
    public class BankAccount
    {
        public string AccountHolderName { get; private set; }
        public double Balance { get; private set; }
        private const double MinimumBalance = 1000.0;

        public BankAccount(string name, double initialBalance)
        {
            if (initialBalance < MinimumBalance)
                throw new ArgumentException($"Initial balance must be at least ₹{MinimumBalance}.");
            AccountHolderName = name;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be positive.");
            Balance += amount;
            Console.WriteLine($"[SUCCESS] Deposited ₹{amount}. New Balance: ₹{Balance}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be positive.");
            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance.");
            if (Balance - amount < MinimumBalance)
                throw new InsufficientBalanceException($"Minimum balance of ₹{MinimumBalance} required.");
            
            Balance -= amount;
            Console.WriteLine($"[SUCCESS] Withdrew ₹{amount}. New Balance: ₹{Balance}");
        }
    }
}
