# Verification Notes

## Project Path
C:\Users\livel\Desktop\Wipro main\Wipro-Training-2026\Module-07-Devops\Assignments\TechSphereContactCMS

## Backend
npm install: passed
npm test: passed
Test result: 2 passed test suites, 7 passed tests total
npm start command: npm start
Health route: http://localhost:5000/api/health

## Frontend
npm install: passed
npm run build: passed
npm run dev command: npm run dev
Local frontend: http://localhost:5173

## GitHub Actions
Workflow file: .github/workflows/ci-cd.yml
What it does: runs backend tests and frontend build before deployment

## Files To Screenshot
1. Backend npm test passed
2. Frontend npm run build passed
3. API health route working
4. Frontend contact page
5. GitHub Actions successful run
6. Pull request merged
7. MongoDB Atlas collection

## Next Manual Steps
1. Add real MongoDB Atlas URI in api/.env
2. Run backend with npm start
3. Run frontend with npm run dev
4. Push code to GitHub
5. Create feature branch and PR
6. Add GitHub secrets
7. Deploy API and frontend
