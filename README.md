# 🎮 GameStore API

Eine einfache REST API zum Verwalten von Videospielen, erstellt mit ASP.NET Core Minimal API.
Dieses Projekt dient als Lernprojekt für CRUD-Operationen und RESTful Web APIs.

## 🚀 Features

* GET alle Spiele
* GET Spiel nach ID
* POST neues Spiel hinzufügen
* PUT Spiel aktualisieren
* DELETE Spiel löschen
* Verwendung von DTOs
* Minimal API in ASP.NET Core

## 🛠️ Technologien

* .NET 8
* ASP.NET Core Minimal API
* C#
* REST API
* DTO Pattern

## ▶️ Projekt starten

```bash
dotnet run
```

Danach läuft die API unter:

```
http://localhost:5281
```

## 📡 API Endpoints

### GET alle Spiele

```
GET /games
```

### GET Spiel nach ID

```
GET /games/{id}
```

### Neues Spiel erstellen

```
POST /games
```

Beispiel Body:

```json
{
  "name": "Cyberpunk 2077",
  "gender": "RPG",
  "price": 49.99,
  "releaseDate": "2020-12-10"
}
```

### Spiel aktualisieren

```
PUT /games/{id}
```

### Spiel löschen

```
DELETE /games/{id}
```

## 📂 Projektstruktur

```
GameStore.Api
│
├── Dtos
│   ├── GameDto.cs
│   ├── CreateGameDto.cs
│   └── UpdateGameDto.cs
│
└── Program.cs
```

## 🎯 Lernziele

* REST API verstehen
* CRUD Operationen implementieren
* DTO Pattern anwenden
* Minimal API verwenden

## 📄 License

MIT License
