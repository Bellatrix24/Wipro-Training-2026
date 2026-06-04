# Day 33: Monolith v/s Microservices and Ocelot API Gateways

Hey there! Today we explored how systems scale, comparing single massive applications with decoupled microservices, and how an API gateway acts as a bouncer at the door to route client requests to the right service.

---

## 1. The Monolithic Structural Dilemma

In our early lab days, we built monolithic applications—where the frontend, database context, user handling, products, and checkout logic are compiled into one single deployable program. 

But as companies grow, this structure becomes a major headache. Let's think about a real-world scenario: **Swiggy or Zomato during a massive weekend sale.**
*   If the payment gateway module experiences a sudden error or crashes due to overload, the *entire* application goes down with it.
*   Because everything is bundled together, fixing a minor bug in the payment code requires rebuilding and redeploying the *whole* application. That means taking down the food listing search, delivery tracking, and restaurant menus too!
*   It makes maintenance incredibly difficult as the team grows, because everyone is editing the same codebase, resulting in merge conflicts and deployment delays.

---

## 2. The Microservices Solution

Microservices break that single giant codebase into small, self-contained applications that run independently. Here is a quick comparison table I made to keep the differences straight:

| Feature / Aspect | Monolithic Architecture | Microservices Architecture |
| :--- | :--- | :--- |
| **Deployment** | All or nothing. Single deployable unit. | Independent. Each service can be updated separately without touching others. |
| **Database** | Shared database. All modules read/write to the same DB. | Decentralized. Each service owns its own database (Database-per-Service). |
| **Fault Isolation** | Poor. A bug in one module can crash the whole app. | Excellent. If the Payment service crashes, users can still search and add items to their carts. |
| **Technology Stack** | Single tech stack (e.g., must write everything in C#). | Polyglot. Billing can use C#, Recommendations can use Python, and search can use Go. |

---

## 3. When to Choose Each Track

We learned that microservices aren't a silver bullet; they add network latency and complexity. Here is the decision boundary we laid out in the lab:

### Traditional Web API (Monolith)
*   **Best for:** Small to medium projects, MVP prototypes, simple CRUD systems, and small development teams.
*   **Why:** It's faster to build, easier to test locally, and doesn't require managing complex docker clusters or API gateways.

### Microservices Architecture
*   **Best for:** Large enterprise platforms (like Netflix, Amazon, or Swiggy).
*   **Why:** Netflix has thousands of services (billing, stream encoding, user profile, recommendations). Using a monolith for that scale would be impossible. They need independent teams deploying updates daily without breaking the rest of the site.
