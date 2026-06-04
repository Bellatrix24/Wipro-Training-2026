# Day 37: Cloud-Native Architecture Foundations and Azure Hosting

Welcome to my Day 37 training overview! Today, I explored cloud computing foundations, the differences between deployment models, and the step-by-step process of deploying applications to Azure App Service.

---

## 1. Business Impact: CapEx vs. OpEx

One of today's key takeaways was understanding the financial shift when migrating to the cloud:

*   **Capital Expenditure (CapEx):** 
    *   *What it is:* Spending money upfront on physical assets (like buying physical servers, networking racks, and building data centers).
    *   *Business Impact:* Requires massive initial budgets. It leaves businesses stuck with depreciating assets and overhead costs (power, cooling, maintenance) regardless of whether the servers are fully utilized.
*   **Operational Expenditure (OpEx):**
    *   *What it is:* Paying for services or products on a flexible, pay-as-you-go subscription basis.
    *   *Business Impact:* No upfront server costs. Businesses only pay for the exact compute power and storage they consume. They can easily scale resources up during traffic spikes or scale them down during quiet hours to save money.

---

## 2. Sandbox DB Connection Settings

For database connections during local development and testing loops, we use these standard parameters to ensure encryption:

```text
Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;
```

*   **Trusted_Connection=True:** Connects securely using our current local OS credentials.
*   **Encrypt=True:** Enforces connection encryption to prevent snooping on our data traffic.

---

## 3. Directory Layout Check

Here is the folder structure for today's cloud hosting and deployment tasks:

```
Module-07-Devops/
└── Day-37-CloudNative-Azure/
    ├── README.md
    ├── CloudNative_And_Azure_Hosting_Notes.md
    └── Azure_AppService_Deployment_Walkthrough.md
```

---

## 4. Repository Tracking
*   Project Repository: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
