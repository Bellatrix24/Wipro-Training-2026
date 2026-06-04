# Assignment Submission Summary - Basic CICD Pipeline for a Full-Stack App

Here is the summary of deliverables for the Day 54 DevOps / CI-CD assignment.

## Project Structure
```text
Basic CICD Pipeline for a Full-Stack App/
├── .github/
│   └── workflows/
│       └── deploy.yml              # CI/CD pipeline
├── api/
│   ├── .dockerignore               # Backend Docker ignore rules
│   ├── Dockerfile                  # Backend service Dockerfile (Node.js)
│   ├── app.js
│   ├── index.js
│   ├── package.json
│   └── (other API files...)
├── client/
│   ├── .dockerignore               # Frontend Docker ignore rules
│   ├── Dockerfile                  # Frontend service Dockerfile (Nginx)
│   ├── package.json
│   ├── vite.config.js
│   └── (other client files...)
├── docker-compose.yml              # Local multi-container compose configuration
├── README.md                       # Documentation with Docker Compose steps
├── final-submission-checklist.md   # Final audit results checklist
└── submission-summary.md           # This deliverables summary
```

## Files Created
1. `client/Dockerfile` - Serves client on port `3000` via Nginx.
2. `client/.dockerignore` - Ignores local node modules/dist folder.
3. `api/.dockerignore` - Ignores local node modules/env variables.
4. `docker-compose.yml` - Launches mongodb, api, and client.
5. `.github/workflows/deploy.yml` - CI pipeline config.
6. `final-submission-checklist.md` - Verification checklist.
7. `submission-summary.md` - Deliverables summary.

## Files Modified
1. `README.md` - Appended local Docker Compose instructions.

## Docker Setup Summary
* **Database:** `mongodb` standard container on port `27017`.
* **Backend:** `api` node server container on port `5000`, using `MONGO_URI=mongodb://mongodb:27017/contactdb` to talk to the DB service.
* **Frontend:** `client` multi-stage Nginx container serving built React files on port `3000`, pointing to backend at `http://localhost:5000`.

## GitHub Actions Workflow Summary
* **Trigger:** Pushes and Pull Requests on `main` branch.
* **Backend Job:** Installs dependencies and runs backend unit tests (`npm test`).
* **Frontend Job:** Installs dependencies and runs client build check (`npm run build`).
* **Compose Job:** Validates configurations (`docker compose config` and `docker compose build`).
* **Docker Hub Job:** Builds final Docker images and conditional tags/pushes them if secrets (`DOCKER_USERNAME` / `DOCKER_PASSWORD`) exist.

## Local Deployment Steps
To deploy the full-stack app locally using Docker Compose, navigate to the project root and run:
```bash
docker compose up --build
```
* **Frontend Access:** http://localhost:3000
* **Backend Access:** http://localhost:5000/api/health
