# Day 37: Azure App Service Deployment Walkthrough

Hey! This is my step-by-step cheat sheet for deploying our web applications to Azure App Service (PaaS). It tracks how to set up resources, publish code from our environment, and secure sensitive configuration parameters.

---

## 1. Phase 1: Set Up Azure Portal Resources

Before we publish our code, we must reserve hosting resources inside the Azure Portal:

1.  **Select Subscription:** Choose the active Azure subscription billing account (usually our sandbox or student account).
2.  **Define Resource Group:** A Resource Group is just a logical container. We group related resources (App Service, Database, Storage) together so we can manage or delete them easily.
3.  **Specify App Name:** Enter a unique web app name (e.g., `wipro-employee-api-dev`), which forms the public URL: `https://wipro-employee-api-dev.azurewebsites.net`.
4.  **Choose Runtime Stack:** Select the server execution environment that matches our build (e.g., **.NET 8 (LTS)**).
5.  **Select App Service Plan (Pricing Tier):**
    *   *Free F1 Tier:* Perfect for training and small lab tests (provides shared infrastructure with 60 mins of daily CPU time at zero cost).
    *   *Basic B1 Tier:* Best for small dev/testing builds (provides dedicated VMs and SSL support).

---

## 2. Phase 2: Publish Code from the IDE

Once our cloud slot is ready, we can deploy the compiled binaries:

*   **From Visual Studio:**
    1.  Right-click our Web API project in the Solution Explorer and select **Publish**.
    2.  Choose **Azure** as the target, followed by **Azure App Service (Windows/Linux)**.
    3.  Log in to our Wipro/Azure account, select our resource group, and choose our App Service.
    4.  Click **Publish** to build the project and upload the files to Azure.
*   **From VS Code (via Azure Resources Extension):**
    1.  Install the **Azure App Service** extension.
    2.  Log in to Azure in VS Code, find the App Service slot, right-click, and select **Deploy to Web App**.
    3.  Select the project workspace folder and confirm the deployment prompt.

---

## 3. Phase 3: Configure Environment Variables

We must never hardcode connection strings, database passwords, or private JWT secret keys inside our code files or `appsettings.json`. Instead, we configure them in Azure:

1.  Open the Azure Portal and navigate to our deployed **App Service**.
2.  Under the left sidebar settings menu, click on **Environment Variables** (or **Configuration** in older portal layouts).
3.  Click **Add** to enter a new key-value parameter:
    *   *Name:* `ConnectionStrings__DefaultConnection` (or `JwtSettings__JwtKey`)
    *   *Value:* Insert the actual production database password or signing key string.
4.  Click **Apply** and **Save**.
5.  *Trainee Study Note:* ASP.NET Core automatically reads these variables and overrides our local `appsettings.json` parameters. This keeps our secrets secure and out of our GitHub repository!
