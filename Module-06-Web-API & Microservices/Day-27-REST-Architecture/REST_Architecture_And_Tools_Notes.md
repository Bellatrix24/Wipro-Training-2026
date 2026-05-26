# Day 27: REST Architecture Principles & API Testing Tools

Hello! This is my Wipro trainee study notes for Day 27. Today we transitioned from building model-view-controller web setups to building **RESTful APIs** that serve raw data payloads. We also explored Postman and Fiddler to intercept, inspect, and test our API network packets.

---

## Foundational Concepts of REST Architecture

In our previous MVC labs, our C# server did two things: it fetched data from the database *and* generated the HTML markup (Views) for the browser to render. 

Today we learned about **REST (REpresentational State Transfer)**, which decouples these duties completely:
* REST is an architectural design style that uses standard HTTP protocols to transfer lightweight, structured data (typically in JSON format) over the web.
* Instead of rendering complex user interface screens, the backend server exposes **endpoints** (URLs). The client application (which could be a React frontend, an Android mobile app, or a desktop client) fetches the raw JSON data from these endpoints and draws the UI itself.
* This separation of concerns allows a single backend API to serve multiple different client interfaces!

---

## Core HTTP Verbs for CRUD Operations

REST utilizes standard HTTP methods (verbs) to determine what action to perform on a resource. Here is my quick trainee reference table:

| HTTP Verb | CRUD Mapping | Description | Safe / Idempotent |
| :--- | :--- | :--- | :--- |
| **GET** | Read | Retrieves a resource or a list of data from the server. | Safe & Idempotent (does not modify server state). |
| **POST** | Create | Sends a new payload to the backend to insert a fresh resource record. | Unsafe & Non-Idempotent (adds new entries). |
| **PUT** | Update | Replaces or updates an entire existing resource record completely. | Unsafe & Idempotent (running it 10 times results in the same state). |
| **DELETE** | Delete | Permanently drops a targeted resource from the persistent storage system. | Unsafe & Idempotent (subsequent deletes do nothing new). |

---

## Core API Verification Testing Tools

Since Web APIs do not render a user interface, we cannot test them simply by opening a standard web browser. We use specialized debugging tools instead:

### Postman Overview
* **What it is:** A graphical API testing client.
* **Why we use it:** Postman allows us to construct customized HTTP requests (GET, POST, PUT, DELETE) on the fly. We can define headers, inject body payloads (JSON strings), inspect response payloads and status codes, organize requests into saveable **Collection** files, and easily mock server responses.

### Fiddler Web Debugger Overview
* **What it is:** A powerful local proxy tool that sits directly between our C# application (or browser) and the internet.
* **Why we use it:** Fiddler intercepts all raw network traffic packets moving in and out of our machine. It allows us to view raw request headers, analyze TLS encryption details, inspect cookie payloads, and trace network response bottlenecks to find out why a network request is taking too long.
