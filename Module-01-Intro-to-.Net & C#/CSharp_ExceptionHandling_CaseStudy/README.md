# CSharp_ExceptionHandling_CaseStudy

## Problem Statement
The objective of this case study is to develop a **Banking Transaction System** that strictly enforces business rules using C# exception handling mechanisms. The system must manage a `BankAccount` with an initial balance, ensuring that a **Minimum Balance of ₹1000** is maintained after any withdrawal. Transactions involving non-positive amounts must be rejected.

## Exception Types Used
1.  **`InsufficientBalanceException`** (Custom): Thrown when a withdrawal exceeds the available balance or violates the ₹1000 minimum balance rule.
2.  **`InvalidAmountException`** (Custom): Thrown when a deposit or withdrawal amount is less than or equal to zero.
3.  **`ArgumentException`** (Standard): Used during account initialization to validate the starting balance.
4.  **`Exception`** (Standard): Catch-all for unexpected runtime anomalies.

## Sample Outputs

### Case A: Valid Transactions
```text
Account created for John Doe with ₹5000
[SUCCESS] Deposited ₹1000. New Balance: ₹6000
[SUCCESS] Withdrew ₹2000. New Balance: ₹4000
```

### Case B: Minimum Balance Violation
```text
Attempting to violate min balance...
[ERROR] Minimum balance of ₹1000 required.
```

### Case C: Invalid Deposit Amount
```text
Attempting negative deposit...
[ERROR] Deposit amount must be positive.
```

### Final System State
```text
--------------------------------------------
Final Balance: ₹4000
Cleanup: Closing system sessions. Clean exit.
--------------------------------------------
```

---
*Verified for Wipro Training 2026 - Day 5 Module 01 Assessment*
