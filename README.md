# Eneba Internship Task (React + .NET + Supabase Postgres)

## Live Demo
- Frontend (Vercel): TBD
- Backend (Render): TBD

## Tech Stack
- Frontend: React (Vite)
- Backend: ASP.NET Core Web API (.NET)
- Database: Supabase Postgres

## API
- GET /list
- GET /list?search=<query>

## Run locally
### Backend
cd server/Eneba.Api
set DATABASE_URL=Host=db.nbklxaohifzfvdeihfnq.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=***;Ssl Mode=Require;Trust Server Certificate=true
dotnet run --urls=http://localhost:5000

### Frontend
cd client
# client/.env => VITE_API_URL=http://localhost:5000
npm i
npm run dev