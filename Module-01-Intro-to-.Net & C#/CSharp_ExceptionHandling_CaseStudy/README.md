# CSharp_ExceptionHandling_CaseStudy

## Banking Transaction System

This repository contains a production-ready C# implementation of a Banking Transaction System, focusing on robust Exception Handling and Business Rule enforcement.

### Core Business Rules
- **Minimum Balance**: A constant threshold of ₹1000 must be maintained at all times.
- **Deposit Validation**: Only positive amounts are accepted; otherwise, an `InvalidAmountException` is thrown.
- **Withdrawal Validation**: Transactions are rejected if:
    1. The amount is non-positive.
    2. The amount exceeds the current balance.
    3. The transaction would cause the balance to drop below the ₹1000 threshold.

### Technical Implementation
- **Custom Exceptions**:
    - `InsufficientBalanceException`: Managed via business rule validation for minimum thresholds.
    - `InvalidAmountException`: Enforces logical consistency for transaction values.
- **Error Handling Architecture**: Implementation of `Try-Catch-Finally` blocks to ensure graceful degradation and reliable state reporting (Final Balance) even in error scenarios.

### Test Scenarios Included
1. **Valid Flow**: Successive deposit and withdrawal within limits.
2. **Threshold Violation**: Attempted withdrawal that would leave the account below ₹1000.
3. **Domain Integrity**: Attempted deposit of a negative amount.

---
*Developed for Module 01 - Day 5 Assessment*
