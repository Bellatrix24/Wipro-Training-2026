# Day 27: REST Architecture Principles & API Testing

This folder contains my training notes and practicing collection files for Day 27, covering the core guidelines of REST architectures, HTTP payload design, and API verification tools.

---

## Daily Learning Overview

Today's training marked the starting step of our Web API module. We made the conceptual jump from rendering HTML views in ASP.NET Core MVC controllers to serving structured, lightweight **JSON data payloads** directly to client engines. 

```text
Browser/App Client (React/Android) 
       │ (Request: HTTP GET /api/students)
       ▼
ASP.NET Core Web API Controller
       │ (EF Core DB Query Processing)
       ▼
SQL Server Database Engine
       │ (Relational Data Table Fetch)
       ▼
C# Objects serialization
       │ (Response: lightweight JSON payload array)
       ▼
Client UI Rendering Engine (Renders visual components dynamically)
```

---

## Debugging Flows in API Development

Because RESTful services do not expose graphical HTML elements to verify, we tested our endpoints using two primary debugging pipelines:

1. **Dispatching Requests via Postman Collections:**
   We built API testing workflows inside [Sample_Postman_Collection.json](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-27-REST-Architecture/Sample_Postman_Collection.json). This allows us to dispatch HTTP requests with specific headers, inject request bodies, and check JSON response payloads instantly.
2. **Monitoring Raw Packets in Fiddler Proxy Streams:**
   We routed local API calls through the Fiddler debugging proxy, intercepting raw TCP packets to analyze transport header flags, evaluate execution bottlenecks, and trace TLS encryption handshakes.

---

## Practicing Assets

Our current directory contains the following training files:
* **[REST_Architecture_And_Tools_Notes.md](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-27-REST-Architecture/REST_Architecture_And_Tools_Notes.md)**: Conceptual guide covering Representational State Transfer, HTTP verbs comparison matrix, and Postman/Fiddler utility guides.
* **[Sample_Postman_Collection.json](file:///c:/Users/livel/Desktop/Wipro%20main/Wipro-Training-2026/Module-06-Web-API%20&%20Microservices/Day-27-REST-Architecture/Sample_Postman_Collection.json)**: A lightweight Postman Collection V2.1 schema containing GET and POST requests configured for localhost student catalog routes.

---

## Repository Tracking

All daily API architectural assets are tracked in our main git catalog:
* Repository URL: [https://github.com/Bellatrix24/Wipro-Training-2026.git](https://github.com/Bellatrix24/Wipro-Training-2026.git)
