# Final Submission Checklist - Basic CICD Pipeline for a Full-Stack App

This checklist summarizes the audit results for the Day 54 DevOps / CI-CD assignment.

## Deliverables Audit

- [x] **Backend Dockerfile (`api/Dockerfile`)**
  - Node.js 20 base image, standard lightweight alpine version.
  - Exposes port `5000` and starts with `npm start`.
- [x] **Frontend Dockerfile (`client/Dockerfile`)**
  - Multi-stage build with Node.js 20 build-stage and Nginx serve-stage.
  - Injects `VITE_API_BASE_URL` at build-time.
  - Custom Nginx server listening on port `3000` to serve the static bundle.
- [x] **Docker Compose Configuration (`docker-compose.yml`)**
  - Sets up `mongodb` (on port `27017`), `api` (on port `5000`), and `client` (on port `3000`).
  - Sets `MONGO_URI=mongodb://mongodb:27017/contactdb` for the backend container.
  - Injects `VITE_API_BASE_URL=http://localhost:5000` to the frontend context.
- [x] **GitHub Actions Workflow (`.github/workflows/deploy.yml`)**
  - Runs on `push` and `pull_request` to `main` branch.
  - Runs Jest backend tests (`npm test`).
  - Verifies the frontend Vite build (`npm run build`).
  - Checks Docker Compose configurations (`docker compose config` & `docker compose build`).
  - Builds local Docker images (`contact-api:latest`, `contact-client:latest`).
  - Safely pushes to Docker Hub using tags only when `DOCKER_USERNAME` and `DOCKER_PASSWORD` secrets are defined.
- [x] **README Updates (`README.md`)**
  - Appended simple local Docker Compose deployment steps.
  - Updated the pipeline reference file to `deploy.yml`.

---

## Remaining Verification Steps (Local Runtime Only)

Since Docker is not configured on this environment, you will need to run the final verification steps locally on your machine once Docker Desktop is running.

### Commands to Run Later:
To start the entire application ecosystem locally, run the following command from the project root:
```bash
docker compose up --build
```

### URLs to Verify locally:
1. **Frontend App:** http://localhost:3000
2. **Backend API Health Check:** http://localhost:5000/api/health
3. **Contact Fetching:** Ensure the UI populates the list of contacts from the MongoDB instance without throwing connection errors.
