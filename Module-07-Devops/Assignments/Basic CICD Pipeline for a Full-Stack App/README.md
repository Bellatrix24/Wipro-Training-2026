# TechSphere Contact CMS

## Objective
A simple student project to build, test, and deploy a Contact Management System for the Wipro DevOps practical exam.

## Tech Used
- **Backend:** Node.js, Express, MongoDB with Mongoose, Jest, Supertest
- **Frontend:** React.js, Vite, Vanilla CSS
- **DevOps:** Docker, GitHub Actions CI/CD

## API Routes
- `GET /api/health` - check backend status
- `GET /api/contacts` - list all contacts
- `GET /api/contacts/:id` - get one contact
- `POST /api/contacts` - add contact
- `PUT /api/contacts/:id` - edit contact
- `DELETE /api/contacts/:id` - delete contact

## How to Run Backend
1. Go to backend directory:
   ```bash
   cd api
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Set env variables in `.env` (copy from `.env.example`).
4. Run server:
   ```bash
   npm start
   ```

## How to Run Frontend
1. Go to frontend directory:
   ```bash
   cd client
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Set env variables in `.env` (copy from `.env.example`).
4. Run local server:
   ```bash
   npm run dev
   ```

## How to Run Tests
1. Go to backend directory:
   ```bash
   cd api
   ```
2. Run test command:
   ```bash
   npm test
   ```

## Docker Command
1. Build backend image:
   ```bash
   docker build -t contact-api ./api
   ```
2. Run backend container:
   ```bash
   docker run -p 5000:5000 --env-file ./api/.env contact-api
   ```

### Local Docker Compose Deployment (Day 54)
Build and run all services (database, backend, frontend) locally:
```bash
docker compose up --build
```
* **Frontend:** http://localhost:3000
* **Backend:** http://localhost:5000/api/health

## GitHub Actions Explanation
The CI/CD workflow is configured in `.github/workflows/deploy.yml`. It runs automatically when you push or make a pull request to the `main` branch. It sets up Node 20, installs dependencies, runs backend tests, and builds the frontend React project.

## Branching Strategy
We use Git branching strategy. We keep the `main` branch stable. We create feature branches (e.g., `feature/contact-crud`) for writing code, and then open a pull request (PR) to merge changes into the `main` branch after peer review and pipeline verification.

## Deployment Links
- **API URL:** `[Insert API deployment link here]`
- **Frontend URL:** `[Insert frontend deployment link here]`
- **GitHub Repo:** `[Insert GitHub repository link here]`

## Screenshot Placeholders
- **GitHub repo structure:** `[Insert screenshot of repo structure here]`
- **npm test passed:** `[Insert screenshot of passing Jest tests here]`
- **GitHub Actions passed:** `[Insert screenshot of successful workflow run here]`
- **API health route:** `[Insert screenshot of /api/health endpoint JSON response here]`
- **Frontend deployed:** `[Insert screenshot of running deployed frontend here]`
- **MongoDB Atlas collection:** `[Insert screenshot of MongoDB Atlas contacts collection here]`
- **Pull request merged:** `[Insert screenshot of merged PR on GitHub here]`
