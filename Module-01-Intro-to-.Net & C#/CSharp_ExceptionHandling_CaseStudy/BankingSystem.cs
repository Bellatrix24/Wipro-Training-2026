using System;

/*
 * Case Study: Banking Transaction System
 * Objective: Demonstrate Exception Handling, Custom Exceptions, and Business Rule Validation.
 * Author: Trainee / Antigravity
 */

namespace BankingSystemApp
{
    // --- 1. CUSTOM EXCEPTIONS ---

    /// <summary>
    /// Thrown when a withdrawal violates balance constraints.
    /// </summary>
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    /// <summary>
    /// Thrown when an invalid amount (zero or negative) is provided for a transaction.
    /// </summary>
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    // --- 2. CORE DOMAIN MODEL ---

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

        /// <summary>
        /// Deposits an amount into the account.
        /// </summary>
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Deposit amount must be positive and greater than zero.");

            Balance += amount;
            Console.WriteLine($"[SUCCESS] Deposited ₹{amount}. New Balance: ₹{Balance}");
        }

        /// <summary>
        /// Withdraws an amount from the account while maintaining the ₹1000 threshold.
        /// </summary>
        public void Withdraw(double amount)
        {
            // Requirement: Validate amount is positive
            if (amount <= 0)
                throw new InvalidAmountException("Withdrawal amount must be positive.");

            // Requirement: Validate sufficient balance
            if (amount > Balance)
                throw new InsufficientBalanceException("Insufficient balance for this transaction.");

            // Requirement: Ensure ₹1000 minimum balance is maintained
            if (Balance - amount < MinimumBalance)
                throw new InsufficientBalanceException($"Transaction rejected. Minimum balance of ₹{MinimumBalance} must be maintained.");

            Balance -= amount;
            Console.WriteLine($"[SUCCESS] Withdrew ₹{amount}. New Balance: ₹{Balance}");
        }
    }

    // --- 3. TEST SCENARIOS ---

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Banking Transaction System: Exception Handling Case Study ===\n");

            BankAccount myAccount = null;

            try
            {
                // Initialization
                myAccount = new BankAccount("John Doe", 5000);
                Console.WriteLine($"Account created for {myAccount.AccountHolderName} with ₹{myAccount.Balance}\n");

                // --- TEST CASE A: Valid Deposit and Withdrawal ---
                Console.WriteLine("Test Case A: Valid Transactions");
                myAccount.Deposit(2000);
                myAccount.Withdraw(3000);
                Console.WriteLine("--------------------------------------------\n");

                // --- TEST CASE B: Minimum Balance Violation (₹1000 Rule) ---
                Console.WriteLine("Test Case B: Withdrawal violating ₹1000 minimum balance");
                // Current balance is 4000. Withdrawing 3500 would leave 500.
                myAccount.Withdraw(3500); 
                Console.WriteLine("--------------------------------------------\n");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"[ERROR: Insufficient Balance] {ex.Message}");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine($"[ERROR: Invalid Amount] {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[ERROR: Argument Exception] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR: Unexpected Error] {ex.Message}");
            }

            try
            {
                // --- TEST CASE C: Invalid Deposit Amount (Negative) ---
                Console.WriteLine("\nTest Case C: Deposit with negative amount");
                if (myAccount != null)
                {
                    myAccount.Deposit(-500);
                }
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine($"[ERROR: Invalid Amount] {ex.Message}");
            }
            finally
            {
                // --- FINAL OUTPUT ---
                Console.WriteLine("\n--------------------------------------------");
                if (myAccount != null)
                {
                    Console.WriteLine($"Final Account Balance: ₹{myAccount.Balance}");
                }
                Console.WriteLine("System Exit: All operations completed.");
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}
