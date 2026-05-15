# 🎮 GameStore

A full-stack game store application built with **ASP.NET Core** (REST API) and **React + TypeScript** (Frontend), using **SQLite** as database.

---

## 📁 Project Structure

```
GameStore/
├── GameStore.Api/                  # ASP.NET Core Web API
│   ├── Data/                       # DB Context & Migrations
│   ├── Dtos/                       # Data Transfer Objects
│   ├── EndPoints/                  # Minimal API Endpoints
│   ├── Models/                     # Entity Models
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── GameStore.db                # SQLite Database
│   └── Program.cs
│
└── GameStore.React/                # React + TypeScript Frontend (Vite)
    ├── src/                        # React source files
    ├── public/
    ├── index.html
    ├── vite.config.ts
    ├── tsconfig.json
    └── package.json
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [npm](https://www.npmjs.com/)

---

### Backend (ASP.NET Core API)

```bash
cd GameStore.Api
dotnet restore
dotnet run
```

The API will be available at `https://localhost:7000`  
*(check `Properties/launchSettings.json` for the exact port)*

---

### Frontend (React + Vite)

```bash
cd GameStore.React
npm install
npm run dev
```

The frontend will be available at `http://localhost:5173`.

> All `/api/*` requests are automatically proxied to the ASP.NET Core backend via Vite's proxy config.

---

## 🔧 Configuration

### Vite Proxy (`GameStore.React/vite.config.ts`)

```ts
server: {
  proxy: {
    '/api': {
      target: 'https://localhost:7000', // your ASP.NET port
      changeOrigin: true,
      secure: false,
    }
  }
}
```

---

## 🛠️ Tech Stack

| Layer     | Technology                        |
|-----------|-----------------------------------|
| Backend   | ASP.NET Core 8, C#, Minimal APIs |
| Frontend  | React 18, TypeScript, Vite        |
| Database  | SQLite (via Entity Framework Core)|

---

## 📜 License

MIT