# Day 33: Microservices Setup and Gateway Configuration CLI Walkthrough

Hey! Here is my step-by-step CLI cheat-sheet tracking the 27 steps we practiced in the lab to set up, reference, configure, and launch our local microservices solution using Ocelot.

---

## 1. 27-Step CLI Reference Guide

### Phase A: Setting Up the Solution Structure
1.  **Step 1:** Create our main workspace folder.
    ```bash
    mkdir ECommerceApp
    ```
2.  **Step 2:** Go inside the main directory.
    ```bash
    cd ECommerceApp
    ```
3.  **Step 3:** Set up a clean .NET solution container to hold our projects.
    ```bash
    dotnet new sln
    ```

### Phase B: Scaffolding the Product Microservice
4.  **Step 4:** Create a folder for the Product Service.
    ```bash
    mkdir ProductService
    ```
5.  **Step 5:** Enter the new folder.
    ```bash
    cd ProductService
    ```
6.  **Step 6:** Scaffold a new, lightweight Web API project.
    ```bash
    dotnet new webapi
    ```
7.  **Step 7:** Step back out to the solution root.
    ```bash
    cd ..
    ```
8.  **Step 8:** Add the Product service project reference to the solution.
    ```bash
    dotnet sln add ProductService/ProductService.csproj
    ```

### Phase C: Scaffolding the Order Microservice
9.  **Step 9:** Create a folder for the Order Service.
    ```bash
    mkdir OrderService
    ```
10. **Step 10:** Enter the Order folder.
    ```bash
    cd OrderService
    ```
11. **Step 11:** Scaffold the second Web API project.
    ```bash
    dotnet new webapi
    ```
12. **Step 12:** Return to the solution root.
    ```bash
    cd ..
    ```
13. **Step 13:** Add the Order service project reference to the solution.
    ```bash
    dotnet sln add OrderService/OrderService.csproj
    ```

### Phase D: Scaffolding the Ocelot API Gateway
14. **Step 14:** Create a folder for the Gateway.
    ```bash
    mkdir ApiGateway
    ```
15. **Step 15:** Enter the Gateway folder.
    ```bash
    cd ApiGateway
    ```
16. **Step 16:** Scaffold a basic Web API project to host Ocelot.
    ```bash
    dotnet new webapi
    ```
17. **Step 17:** Return to the solution root.
    ```bash
    cd ..
    ```
18. **Step 18:** Add the Gateway project reference to the solution.
    ```bash
    dotnet sln add ApiGateway/ApiGateway.csproj
    ```

### Phase E: Installing and Setting Up Ocelot
19. **Step 19:** Navigate into the ApiGateway directory where our gateway code lives.
    ```bash
    cd ApiGateway
    ```
20. **Step 20:** Install the Ocelot NuGet package driver.
    ```bash
    dotnet add package Ocelot
    ```
21. **Step 21:** Build the configuration file for gateway routes.
    ```bash
    # (Or use notepad, vs code, etc. to write ECommerce_Ocelot_Config.json as ocelot.json)
    echo {} > ocelot.json
    ```

### Phase F: Multi-Terminal Launch and Verification
22. **Step 22:** Spin up the **ProductService** on its dedicated local port in Terminal 1.
    ```bash
    dotnet run --project ../ProductService/ProductService.csproj --urls "http://localhost:5001"
    ```
23. **Step 23:** Open Terminal 2 and spin up the **OrderService** on its local port.
    ```bash
    dotnet run --project ../OrderService/OrderService.csproj --urls "http://localhost:5002"
    ```
24. **Step 24:** Open Terminal 3 and launch the **ApiGateway** on the external access port.
    ```bash
    dotnet run --project ApiGateway.csproj --urls "http://localhost:7000"
    ```
25. **Step 25:** Verify the Product Service is responding directly in terminal 4.
    ```bash
    curl http://localhost:5001/api/products
    ```
26. **Step 26:** Verify the Order Service is responding directly.
    ```bash
    curl http://localhost:5002/api/orders
    ```
27. **Step 27:** Verify Ocelot is routing successfully by sending a request to the Gateway.
    ```bash
    curl http://localhost:7000/gateway/products
    ```

---

## 2. Bonus Dockerization Snippet

Here are the 4 key docker commands we used during our runtime container discussion today:

1.  **Build a Docker Image:**
    Build an image from a local Dockerfile, tagging it with a name we can reference.
    ```bash
    docker build -t inventory-service:v1 .
    ```
2.  **Run a Container Detached:**
    Run the container in the background (detached mode) and map external port 8080 to internal port 80.
    ```bash
    docker run -d -p 8080:80 --name running-inventory inventory-service:v1
    ```
3.  **Monitor Container Statuses:**
    List all active containers to check health status and port mappings.
    ```bash
    docker ps
    ```
4.  **Stop Container Processes:**
    Gracefully halt the running container by referencing its name or container ID.
    ```bash
    docker stop running-inventory
    ```
