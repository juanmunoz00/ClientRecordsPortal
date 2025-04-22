# ClientRecordsPortal

🚧 **Status**: Proof of Concept – under active development

## 📌 Project Overview

ClientRecordsPortal is a secure, token-based API built with **ASP.NET Core 8.0**, designed to manage client records for small-to-medium service-based businesses in the **El Paso–Juarez region**.

This PoC includes:
- 🔐 **JWT Authentication** for secure login and authorization
- 📦 **DTO-based architecture** to separate concerns
- 🔁 **AutoMapper** for clean object mapping
- 📄 **Swagger** for interactive API documentation
- 💾 **SQLite** for lightweight, local database integration

---

## 🧰 Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core + SQLite
- JWT Bearer Authentication
- AutoMapper
- Swagger (Swashbuckle)
- C#

---

## 🚀 Getting Started

### 🧱 Prerequisites

- .NET 8 SDK
- Git
- SQLite tools (optional for DB inspection)

### 📥 Clone the Repo

```bash
git clone https://github.com/your-username/ClientRecordsPortal.git
cd ClientRecordsPortal
dotnet restore
dotnet run
```

### 🌐 Access the API

After running the app:

- API Swagger: http://localhost:5017/swagger
- Test login: `POST /api/Auth/login`

```json
{
  "username": "admin",
  "password": "password"
}
```

Paste the returned token into the **Authorize** button in Swagger.

---

## 🔐 Secured Endpoints

Once authorized, you can access:

- `GET /api/Clients`
- `POST /api/Clients`

All client data uses clean DTOs and is mapped internally via AutoMapper.

---

## 🧪 Roadmap

- ✅ JWT Authentication
- ✅ DTO Separation
- ✅ AutoMapper Integration
- ✅ Swagger Security
- ⏳ FluentValidation for DTOs
- ⏳ Unit Testing (xUnit)
- ⏳ GitHub Actions CI/CD
- ⏳ MAUI Client Integration

---

## 👤 Author

**Juan Muñoz** – Software Engineer | El Paso–Juárez Border Region  
📧 [Your Email]  
🌐 [Your Website or LinkedIn]

---

## 📄 License

This project is open-source for demonstration and internal use. License TBD.
