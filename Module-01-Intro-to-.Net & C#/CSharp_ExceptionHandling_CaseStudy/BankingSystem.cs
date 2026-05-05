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
    }
}
