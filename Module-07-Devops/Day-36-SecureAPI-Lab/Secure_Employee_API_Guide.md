# Day 36: Secure Employee API Lab & Verification Guide

Hey! Here is our lab guide and business case study for the **TechNova Solutions Secure Portal** project. Today, we applied our JWT theory to build a working, secure API and tested how the endpoints react to different client tokens.

---

## 1. Business Scenario Requirements

TechNova Solutions needs a secure internal employee directory application. The system has two major security rules we had to enforce in our API layout:

1.  **Authentication Gateway:** Employees must log in using their credentials through a dedicated endpoint. Upon successful verification, the API issues them a dynamically generated JSON Web Token (JWT).
2.  **Protected Endpoints:** Confidential data, such as employee salary metrics, phone lists, and home addresses, must be strictly blocked from public access. The API should reject any client request that doesn't provide a valid token.

---

## 2. Validation Matrix

To verify our security controls work exactly as specified, we mapped out a validation matrix. We tested each scenario manually using Swagger and Postman:

| Scenario / Action | Provided Token State | Expected Result | Technical Status Code |
| :--- | :--- | :--- | :--- |
| **Anonymous Access Test** | No token provided in the header. | The request is intercepted and blocked immediately. | `401 Unauthorized` |
| **Authenticated Access Test** | A valid, active JWT signed by our server. | The bouncer lets the request pass and returns the employee list. | `200 OK` (with JSON data) |
| **Tampered Token Test** | Token payload modified (e.g., changed username or roles). | The signature verification fails. The gateway rejects the call. | `401 Unauthorized` |
| **Expired Token Test** | Token time limit exceeded (e.g., token generated 2 hours ago). | The middleware detects the expired timestamp and blocks access. | `401 Unauthorized` |

---

## 3. Trainee Practice Notes

When working on these labs, remember:
*   Never share or commit the private symmetric key used to sign tokens. Keep it safe in configuration files.
*   Always use HTTPS in production so tokens cannot be sniffed while in transit across the network.
*   Set a reasonable token expiration time (like 15 to 30 minutes) to minimize the damage if a token gets stolen by an unauthorized client.
