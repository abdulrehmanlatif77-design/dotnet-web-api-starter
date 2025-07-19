# VertexCore - ASP.NET Core Clean Architecture Template

<div align="center">
  <img src="assets/vertexcore-icon.png" alt="VertexCore Logo" width="320" height="180"/>
  
  ![Clean Architecture Banner](https://via.placeholder.com/800x300/2E3440/88C0D0?text=Clean+Architecture+Template)
</div>

[![.NET](https://img.shields.io/badge/.NET-9.0-purple)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-blue)](https://docs.microsoft.com/en-us/aspnet/core/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208.0-green)](https://docs.microsoft.com/en-us/ef/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

## 📋 Overview

**VertexCore** is a production-ready ASP.NET Core Web API template built with **Clean Architecture** principles. It provides a solid foundation for building scalable, maintainable, and testable web APIs with modern development practices.

### 🎯 Key Features

- ✅ **Clean Architecture** - Well-structured, maintainable codebase
- ✅ **CQRS Pattern** - Command Query Responsibility Segregation with MediatR
- ✅ **JWT Authentication** - Secure token-based authentication
- ✅ **ASP.NET Core Identity** - Complete user management system
- ✅ **Entity Framework Core** - Code-first database approach
- ✅ **FluentValidation** - Robust input validation
- ✅ **Result Pattern** - Consistent API response structure
- ✅ **Swagger/OpenAPI** - Interactive API documentation
- ✅ **Serilog Logging** - Structured logging to file and console
- ✅ **Exception Handling** - Global exception handling middleware
- ✅ **Dependency Injection** - Built-in IoC container configuration

## 🏗️ Architecture

This template follows the **Clean Architecture** pattern with four main layers:

```
📁 dotnet-web-api-starter/
├── 📄 dotnet-web-api-starter.sln
└── 📁 src/
    ├── 📁 VertexCore.Domain/
    │   ├── 📄 VertexCore.Domain.csproj
    │   ├── 📁 Entities/
    │   │   ├── 📄 BaseEntity.cs
    │   │   ├── 📄 Order.cs
    │   │   ├── 📄 OrderItem.cs
    │   │   └── 📄 Product.cs
    │   ├── 📁 DTOs/
    │   │   ├── 📄 LoginResultDto.cs
    │   │   └── 📄 TokenUserDto.cs
    │   ├── 📁 Enums/
    │   │   └── 📄 OrderStatus.cs
    │   └── 📁 Interfaces/
    │       ├── 📁 Repositories/
    │       └── 📁 Services/
    │           └── 📄 ITokenService.cs
    │
    ├── 📁 VertexCore.Application/
    │   ├── 📄 VertexCore.Application.csproj
    │   ├── 📁 Commands/
    │   │   ├── 📁 Auth/
    │   │   │   ├── 📄 CreateUserCommand.cs
    │   │   │   └── 📄 LoginCommand.cs
    │   │   ├── 📁 Orders/
    │   │   ├── 📁 Products/
    │   │   └── 📁 Users/
    │   ├── 📁 Queries/
    │   │   ├── 📁 Orders/
    │   │   └── 📁 Products/
    │   ├── 📁 Validators/
    │   │   └── 📁 Auth/
    │   │       ├── 📄 CreateUserCommandValidator.cs
    │   │       └── 📄 LoginCommandValidator.cs
    │   ├── 📁 Common/
    │   │   ├── 📁 Behaviors/
    │   │   │   └── 📄 ValidationBehavior.cs
    │   │   └── 📁 Models/
    │   │       ├── 📄 Error.cs
    │   │       └── 📄 Result.cs
    │   ├── 📁 Helpers/
    │   │   └── 📄 PasswordHasher.cs
    │   └── 📁 Interfaces/
    │
    ├── 📁 VertexCore.Infrastructure/
    │   ├── 📄 VertexCore.Infrastructure.csproj
    │   ├── 📁 Identity/
    │   │   ├── 📄 ApplicationDbContext.cs
    │   │   ├── 📄 AppUser.cs
    │   │   └── 📁 Seed/
    │   │       └── 📄 IdentitySeeder.cs
    │   ├── 📁 Configuration/
    │   │   ├── 📄 JWTSettings.cs
    │   │   ├── 📁 EntityConfigurations/
    │   │   │   ├── 📄 OrderConfiguration.cs
    │   │   │   ├── 📄 OrderItemConfiguration.cs
    │   │   │   └── 📄 ProductConfiguration.cs
    │   │   └── 📁 IdentityConfigurations/
    │   │       └── 📄 AppUserConfiguration.cs
    │   ├── 📁 Services/
    │   │   ├── 📄 TokenService.cs
    │   │   └── 📁 Auth/
    │   │       └── 📄 AuthService.cs
    │   ├── 📁 Interfaces/
    │   │   ├── 📄 ITokenParser.cs
    │   │   ├── 📁 Repositories/
    │   │   └── 📁 Services/
    │   │       └── 📄 IAuthService.cs
    │   ├── 📁 Repositories/
    │   └── 📁 Migrations/
    │
    └── 📁 VertexCore.WebAPI/
        ├── 📄 VertexCore.WebAPI.csproj
        ├── 📄 Program.cs
        ├── 📁 Controllers/
        │   └── 📁 Auth/
        │       └── 📄 AuthController.cs
        ├── 📁 Middleware/
        │   └── 📄 ExceptionHandlingMiddleware.cs
        ├── 📁 Extensions/
        │   └── 📄 ResultExtensions.cs
        ├── 📁 DependencyInjection/
        │   └── 📄 APIServiceRegistration.cs
        ├── 📁 Logger/
        │   └── 📄 SerilogConfigurator.cs
        └── 📁 Properties/
            └── 📄 launchSettings.json
```

## 🚀 Quick Start

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/dotnet-web-api-starter.git
   cd dotnet-web-api-starter
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `src/VertexCore.WebAPI/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=VertexCoreDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update --project .\src\VertexCore.Infrastructure\ -s .\src\VertexCore.WebAPI\
   ```

5. **Run the application**
   ```bash
   dotnet watch run --project .\src\VertexCore.WebAPI\
   ```

6. **Access Swagger UI**
   
   Navigate to: `https://localhost:5112/swagger`

## 📚 Usage Examples

### Authentication

#### Register a new user
```http
POST /api/auth/register
Content-Type: application/json

{
  "userName": "john_doe",
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "userName": "john_doe",
  "password": "SecurePass123!"
}
```

**Response:**
```json
{
  "isSuccess": true,
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "user": {
      "id": "123e4567-e89b-12d3-a456-426614174000",
      "userName": "john_doe",
      "email": "john@example.com"
    }
  },
  "errors": []
}
```

#### Using JWT Token
```http
GET /api/protected-endpoint
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```


## 🛠️ Technology Stack

| Technology | Purpose |
|-----------|---------|
| **ASP.NET Core 8.0** | Web API framework |
| **Entity Framework Core** | Object-Relational Mapping (ORM) |
| **ASP.NET Core Identity** | Authentication & user management |
| **MediatR** | CQRS pattern implementation |
| **FluentValidation** | Input validation |
| **JWT Bearer** | Token-based authentication |
| **Serilog** | Structured logging |
| **AutoMapper** | Object-to-object mapping |
| **Swagger/OpenAPI** | API documentation |

## 📁 Project Structure Details

### Domain Layer (VertexCore.Domain)
- **Pure business logic** - No dependencies on external libraries
- **Entities** - Core business objects
- **Interfaces** - Contracts for services
- **DTOs** - Data transfer objects
- **Enums** - Domain-specific enumerations

### Application Layer (VertexCore.Application)
- **Business rules implementation**
- **CQRS Commands & Queries** - Using MediatR
- **Validation logic** - FluentValidation rules
- **Application services** - Orchestrating domain objects

### Infrastructure Layer (VertexCore.Infrastructure)
- **Data access** - Entity Framework Core
- **External services** - Email, SMS, etc.
- **Identity system** - ASP.NET Core Identity
- **File operations** - File system interactions

### WebAPI Layer (VertexCore.WebAPI)
- **API controllers** - HTTP endpoints
- **Middleware** - Cross-cutting concerns
- **Configuration** - Dependency injection setup
- **Extensions** - Helper methods

## ⚙️ Configuration

### Database Configuration
Update your connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your-Connection-String-Here"
  }
}
```

### JWT Configuration
Configure JWT settings in `appsettings.json`:
```json
{
  "JWTSettings": {
    "Key": "YourSecretKeyHere-MustBe32CharactersLong",
    "Issuer": "VertexCore.WebAPI",
    "Audience": "VertexCore.WebAPI.Users",
    "ExpirationInMinutes": 60
  }
}
```

### Logging Configuration
Serilog is configured to log to both console and files. Logs are stored in the `Logs` folder.


## 📋 API Documentation

Once the application is running, you can access:

- **Swagger UI**: `https://localhost:5112/swagger`
- **API Docs**: `https://localhost:5112/swagger/v1/swagger.json`

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📖 Articles & Blog Posts

Learn more about this project and Clean Architecture implementation:

### 🇺🇸 English Articles
- [Building Clean Architecture with ASP.NET Core - Complete Guide](https://medium.com/@freecnsz/clean-architecture-aspnet-core-guide)

### 🇹🇷 Türkçe Makaleler  
- [ASP.NET Core ile Clean Architecture - Kapsamlı Rehber](https://medium.com/@freecnsz/

*These articles provide in-depth explanations of the concepts and patterns used in this template.*  
*Bu makaleler, bu template'de kullanılan konsept ve pattern'ler hakkında detaylı açıklamalar sağlar.

## �🙏 Acknowledgments

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) by Robert C. Martin
- [MediatR](https://github.com/jbogard/MediatR) for CQRS implementation
- [FluentValidation](https://fluentvalidation.net/) for validation
- ASP.NET Core team for the amazing framework

## 📞 Support

If you have any questions or need help, please:

- 📧 Create an issue on GitHub
- 💬 Start a discussion in the repository
- 🌟 Star the repository if you found it helpful

---

**Happy Coding!** 🚀

---

*Built with ❤️ using ASP.NET Core*