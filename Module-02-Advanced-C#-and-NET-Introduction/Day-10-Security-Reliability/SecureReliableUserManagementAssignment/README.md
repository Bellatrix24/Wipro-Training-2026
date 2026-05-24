# Secure & Reliable User Management System (Day 10)

Welcome to the Day 10 Security and Reliability coding assignment! This project implements a **Secure and Reliable User Management System** in C# (.NET 8+) and incorporates comprehensive unit tests using the **MSTest** framework to verify all logical and structural security requirements under typical and edge cases.

---

## Objective

The objective of this assignment is to understand the core principles of software security and reliability:
1. **Secure Hashing**: Protect credentials using modern irreversible hashing functions (SHA-256) so plain-text passwords are never saved.
2. **Reversible Encryption**: Protect sensitive, non-credential user details using symmetric encryption algorithms (AES).
3. **App Reliability**: Graceful error handling and diagnostic file logging (`app-log.txt`) without exposing exceptions or sensitive info to callers.

---

## Folder Structure

Below is the directory layout of this assignment:

```text
SecureReliableUserManagementAssignment/
├── SecureReliableUserManagementAssignment.sln  # Solution file
├── README.md                                    # This documentation file
│
├── SecureReliableUserManagement/                # Core Security Logic Class Library
│   ├── SecureReliableUserManagement.csproj      # Project configuration
│   ├── Models/
│   │   └── User.cs                              # User domain model
│   └── Services/
│       ├── PasswordHasher.cs                    # SHA-256 Hashing logic
│       ├── EncryptionService.cs                 # AES-256 Encryption logic
│       ├── FileLogger.cs                        # Text-file logging (app-log.txt)
│       └── UserService.cs                       # Registration & Auth coordinator
│
└── SecureReliableUserManagement.Tests/          # MSTest Unit Test Project
    ├── SecureReliableUserManagement.Tests.csproj
    ├── MSTestSettings.cs                        # MSTest configuration (DoNotParallelize)
    ├── UserServiceTests.cs                      # 8 UserService test cases
    ├── EncryptionServiceTests.cs                # 2 EncryptionService test cases
    └── LoggingTests.cs                          # 2 FileLogger test cases
```

---

## Features Implemented

1. **User Registration**: Enforces input validation rules, resolves duplicate username conflicts, hashes passwords, encrypts sensitive metadata, and appends to in-memory store.
2. **User Authentication**: Securely matches candidate inputs with SHA-256 pre-computed hex hashes.
3. **Symmetric Encryption & Decryption**: Employs AES-256 block ciphers to safely translate sensitive details back and forth.
4. **Resilient File Logging**: Appends timestamped audit entries (`[INFO]` and `[ERROR]`) to `app-log.txt` thread-safely.
5. **Aesthetic Exception Handling**: Uses try-catch blocks in service handlers. Prevents information leakages (like database or filesystem paths) to callers, returning fallback outcomes.

---

## Security Practices Used

- **Hex SHA-256 Cryptographic Hashes**: Passwords are saved only as hex hashes. Verified dynamically via re-hashing candidate strings.
- **AES symmetric block cipher**: User details are kept encrypted in memory using a class-level key and Initialization Vector (IV).
- **Audit Logs Filtration**: Logger entries explicitly scrub passwords and raw details, preventing credential leakage in raw logs.
- **Fail-Safe Operations**: Service exceptions are fully caught, logged, and summarized as simple booleans or empty strings, keeping operations reliable and preventing diagnostic disclosures.

---

## Error Handling and Logging Approach

- **FileLogger Appender**: Each log line writes a formatted string `Timestamp [LEVEL] Message` to `app-log.txt` in the execution folder. Errors include exception type, message, and stack trace.
- **Logger Try-Catch Guarantee**: FileLogger calls `WriteToFile` inside a catch-all block, guaranteeing that logging filesystem lock failures or permissions issues never halt or crash the user experience.
- **Test Isolation**: Logging test cases are configured to run sequentially (`[assembly: DoNotParallelize]`) to prevent parallel process lock clashes on the shared `app-log.txt` resource.

---

## How to Build the Project

Ensure you have the .NET SDK installed. In the `SecureReliableUserManagementAssignment/` root directory, execute:

1. Restore the packages:
   ```bash
   dotnet restore
   ```
2. Build the project:
   ```bash
   dotnet build
   ```

Both projects compile with zero warnings and zero errors.

---

## How to Run Tests

To execute the unit test suite:

```bash
dotnet test
```

This runs all **12 unit tests** sequentially, ensuring flawless isolation.

---

## Short Test Summary

The test suite incorporates **12 distinct, independent test cases** spanning three logical namespaces:

| Test Case Name | Target Service | Expected Behavior |
|---|---|---|
| `Register_WithValidUser_ReturnsTrue` | `UserService` | User successfully registered |
| `Register_HashesPasswordBeforeStoring` | `UserService` | Stored credentials are saved only as 64-char SHA-256 hex hashes |
| `Register_WithDuplicateUsername_ReturnsFalse` | `UserService` | Registration blocks duplicate names |
| `Register_WithEmptyUsername_ReturnsFalse` | `UserService` | Validation rejects empty inputs |
| `Authenticate_WithCorrectPassword_ReturnsTrue` | `UserService` | Successful validation returns true |
| `Authenticate_WithWrongPassword_ReturnsFalse` | `UserService` | Wrong password matching returns false |
| `GetDecryptedDetails_ReturnsOriginalDetails` | `UserService` | Successfully decrypts and returns original details |
| `GetDecryptedDetails_WithMissingUser_ReturnsEmptyString` | `UserService` | Missing usernames return `string.Empty` |
| `Encrypt_ReturnsDifferentTextThanOriginal` | `EncryptionService` | Encrypted text is distinct and encoded in valid Base64 |
| `Decrypt_ReturnsOriginalText` | `EncryptionService` | Decryption translates cipher text back to plain text |
| `LogInfo_WritesMessageToFile` | `FileLogger` | Appends formatted `[INFO]` entry to `app-log.txt` |
| `LogError_WritesErrorToFile` | `FileLogger` | Appends formatted `[ERROR]` entry with exception type and trace |

---

## Production Security Notice

> [!IMPORTANT]
> **This is a learning/student assignment only.** 
> In a production enterprise system, you should:
> 1. Use slow-hashing algorithms with unique random salts (such as **BCrypt**, **Argon2**, or **PBKDF2**) rather than fast cryptographic hashes like SHA-256 to protect against GPU-accelerated dictionary attacks.
> 2. Store encryption keys and IV secrets securely using external **Key Vault Services** (e.g. Azure Key Vault, AWS KMS, or HashiCorp Vault) rather than hardcoding them in class files.
