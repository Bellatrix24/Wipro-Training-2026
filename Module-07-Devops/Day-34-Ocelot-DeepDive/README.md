# Day 34: Ocelot API Gateway Deep-Dive & Microservice Hardening

Welcome to my Day 34 training overview! Today, I explored how to secure a multi-service backend by replacing direct client-to-service communication with a hardened API gateway configuration.

---

## 1. Architectural Contrast

We compared two architectural setups to understand the security benefits of an API gateway:

### Without an API Gateway
*   **Direct Invocations:** The client application connects directly to individual backend microservices on their public IP addresses and ports.
*   **Exposure:** Publicly exposes internal service details (like ports `5001`, `5002`, `5003`).
*   **Security Overhead:** Every service has to implement its own authentication, rate limiting, and CORS policies, leading to code duplication and security risks.

### With an Ocelot API Gateway
*   **Decoupled & Insulated:** The client app only speaks to Ocelot (on one secure public port). Ocelot manages routing behind our firewall.
*   **Centralized Security:** We run token validation, logging, and traffic throttling once at the gateway level.
*   **Infrastructure Masking:** Internal microservices are hidden inside a private network, completely shielded from direct public access.

---

## 2. Request Delegation Pipeline

Here is a visual tracking map of how an incoming request travels through our proxy layer down to our private downstream microservices:

```text
[ Client Application ] (Calls public endpoint: https://gateway.wiprotraining.com/gateway/payments/checkout)
         │
         ▼
 ┌────────────────────────────────────────────────────────┐
 │ Ocelot API Gateway (Port 443 / Public Facing)           │
 │                                                        │
 │ 1. Captures incoming URL parameters                    │
 │ 2. Inspects headers & checks authentication token      │
 │ 3. Evaluates rate limiting rules                       │
 │ 4. Decrypts and looks up matching downstream route     │
 └────────────────────────────────────────────────────────┘
         │
         ▼ (Forwards internally over secure private network)
 ┌────────────────────────────────────────────────────────┐
 │ Payment Microservice (Port 4432 / Private downstream)  │
 │                                                        │
 │ 1. Receives internal forwarded call                    │
 │ 2. Executes database transaction                       │
 │ 3. Returns payment status result                       │
 └────────────────────────────────────────────────────────┘
         │
         ▼ (Sends response back through the gateway proxy)
[ Client Application ] (Receives JSON: { "status": "Success" })
```

---

## 3. Directory Layout Check

Here is the file structure for today's gateway hardening and routing deep-dive:

```
Module-07-Devops/
└── Day-34-Ocelot-DeepDive/
    ├── README.md
    ├── Ocelot_Gateway_DeepDive_Notes.md
    └── Secure_Ocelot_Production_Config.json
```

---

## 4. Repository Tracking
*   Project Repository: [Wipro-Training-2026](https://github.com/Bellatrix24/Wipro-Training-2026.git)
