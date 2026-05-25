# Secure Coding Guidelines

Standard software development life cycle (SDLC) practices for defensive programming.

## 1. Input Sanitization and Validation
* Perform server-side validation using declarative attributes in ViewModels.
* Utilize regular expressions to filter out unexpected characters and allow list patterns.
* Sanitize text parameters upon intake to restrict HTML tags or query separators.

## 2. Secure Data Storage
* Never store plain-text passwords. Leverage PBKDF2/bcrypt hashing with high work factors and unique salts.
* Encrypt sensitive database values at rest using AES-256 standard keys.
* Calculate HMAC signatures over combined columns to verify that data has not been modified out-of-band.

## 3. Cryptographic and Database Best Practices
* Rely on Entity Framework Core parameterized query generation to guarantee SQLi immunity.
* Use constant-time comparisons when validating signatures to prevent side-channel timing attacks.
* Store connection credentials and keys securely inside system variables or configuration keys (appsettings), avoiding hardcoded values.

## 4. Secure SDLC
* Enforce secure coding principles at all lifecycle phases.
* Conduct regular code audits, security checklist evaluations, and threat modeling during development.
* Implement least-privilege administrative access policies.
