# Eneba Internship Task — Full-Stack Game List App

A simple full-stack web application that displays a list of games and supports real-time search.  
Built with React (Vite) on the frontend and ASP.NET Core Web API on the backend, using Supabase Postgres as the database.

---

## 🌐 Live Demo

- **Frontend (Netlify):**  
  https://taupe-syrniki-bbeaaf.netlify.app/

- **Backend API (Railway):**  
  https://eneba-intern-task-production.up.railway.app

- **API Documentation (Swagger):**  
  https://eneba-intern-task-production.up.railway.app/swagger

- **Health Check:**  
  https://eneba-intern-task-production.up.railway.app/health

---

## 🧱 Tech Stack

### Frontend
- React (Vite)
- JavaScript (ES6+)
- Fetch API
- Netlify (Hosting)

### Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- Npgsql (PostgreSQL provider)
- CORS enabled for frontend access
- Railway (Hosting)

### Database
- Supabase PostgreSQL (Cloud hosted)

---

## ✨ Features

- Displays a list of games
- Real-time search with debounce
- Responsive card layout
- REST API integration
- Production deployment
- Environment-based configuration

---

## 📡 API Endpoints

Base URL:
https://eneba-intern-task-production.up.railway.app

---

### Get all games

GET /list

---

### Search games by name

GET /list?search=<query>

---

### Health check

GET /health

---

## 🗂️ Project Structure


eneba-intern-task/
├── client/ # React frontend (Vite)
│ ├── src/
│ └── dist/
│
└── server/
└── Eneba.Api/ # ASP.NET Core Web API

---

## ⚙️ Environment Variables

### Backend (.NET)

The backend uses a PostgreSQL connection string stored in `DATABASE_URL`.

Example (Supabase Session Pooler recommended):

DATABASE_URL=Host=aws-1-eu-west-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres;Password=YOUR_PASSWORD;Ssl Mode=Require;Trust Server Certificate=true

⚠️ Never commit real credentials to source control.

---

### Frontend (Vite)

Create a file inside the client folder:

client/.env


Add:

VITE_API_URL=http://localhost:5000


Production value (Netlify environment variable):

VITE_API_URL=https://eneba-intern-task-production.up.railway.app

---

## ▶️ Running Locally

### 1) Backend

Navigate to backend folder:

cd server/Eneba.Api.
---

Set environment variable:

Windows (PowerShell):
$env:DATABASE_URL="Host=...;Port=5432;Database=postgres;Username=postgres;Password=...;Ssl Mode=Require;Trust Server Certificate=true"

Windows (CMD);
set DATABASE_URL=Host=...;Port=5432;Database=postgres;Username=postgres;Password=...;Ssl Mode=Require;Trust Server Certificate=true

macOS / Linux;
export DATABASE_URL="Host=...;Port=5432;Database=postgres;Username=postgres;Password=...;Ssl Mode=Require;Trust Server Certificate=true"

Run the API:
dotnet restore
dotnet run --urls=http://localhost:5000

Backend will be available at:
http://localhost:5000/list
http://localhost:5000/swagger

### 2)Frontend:

Navigate to client folder:
cd client

Install dependencies:
npm install

Run development server:
npm run dev

Frontend will be available at:
http://localhost:5173

---

Deployment
Backend — Railway

Deploy from GitHub repository
Set environment variable DATABASE_URL
Application binds automatically to Railway port
CORS configured to allow frontend domain

Frontend — Netlify

Build settings:
Base directory: client
Build command: npm run build
Publish directory: dist

Environment variable:

VITE_API_URL=https://eneba-intern-task-production.up.railway.app

⚠️ Troubleshooting
Cards not loading

Check browser console for errors:
CORS error → Backend must allow frontend origin
Failed fetch → Incorrect API URL
Empty results → Database may be empty
Database connection issues

Use Supabase Session Pooler connection string if direct connection fails.

📄 License

This project was created as part of an internship technical task.
