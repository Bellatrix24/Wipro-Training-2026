# Basic CI/CD Pipeline for a Full-Stack App

This project contains a simple Contact Management System built using React, Node.js, Express, and MongoDB.

The purpose of this assignment was to add Docker support and a basic GitHub Actions CI/CD pipeline.

## Project Structure

```text
api/
client/
docker-compose.yml
.github/workflows/deploy.yml
```

## Features

* View contacts
* Add contacts
* Edit contacts
* Delete contacts
* MongoDB database
* Backend API using Express
* React frontend

## Run Backend

```bash
cd api
npm install
npm start
```

Backend runs on:

```text
http://localhost:5000
```

## Run Frontend

```bash
cd client
npm install
npm run dev
```

Frontend runs on:

```text
http://localhost:5173
```

## Run Tests

```bash
cd api
npm test
```

## Docker

Build and start all services:

```bash
docker compose up --build
```

Docker services:

* Frontend: http://localhost:3000
* Backend: http://localhost:5000
* MongoDB: localhost:27017

## CI/CD

The GitHub Actions workflow is located at:

```text
.github/workflows/deploy.yml
```

The workflow:

* Installs dependencies
* Runs backend tests
* Builds frontend
* Builds Docker images

## Notes

This project was prepared as part of the Wipro DevOps practical assignment focusing on Docker, Docker Compose, and GitHub Actions.
