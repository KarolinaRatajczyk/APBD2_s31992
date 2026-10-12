# APBD2_s31992

A C# and ASP.NET Core Web API for retrieving employee details and their training records, including training interests and attendance history.

The application uses Entity Framework Core to access a SQL Server database.

## Features

- Retrieve employee details by ID.
- Include the employee's department information.
- List training sessions the employee is interested in.
- List attended training sessions with attendance dates and feedback ratings.
- Delete an employee along with related attendance and training interest records.
- Handle requests for employees that do not exist.

## API Endpoints

```http
GET /api/employees/{id}
DELETE /api/employees/{id}
```

## Tech Stack

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

## Getting Started

Requirements:

- .NET 8 SDK
- SQL Server
- The `dotnet-ef` tool if you use the included migrations to create or update the database

Configure the database connection in `Poprawa_kol2/appsettings.json` before starting the application. The default connection points to an `apbd` database on a local SQL Server instance.

From the repository root:

```bash
cd Poprawa_kol2
dotnet restore
dotnet ef database update
dotnet run
```

## Project Structure

```text
Poprawa_kol2/
├── Controllers/        # Employee API controller
├── DTOs/               # API response objects
├── Data/               # AppDbContext and data configuration
├── Exceptions/         # NotFoundException
├── Migrations/         # Entity Framework Core migrations
├── Models/             # Employee, Training, TrainingAttendance and related models
├── Services/           # Data retrieval and deletion logic
├── Program.cs          # Application configuration
└── appsettings.json    # Database connection settings
```

## Notes

Initial data is defined in `AppDbContext` using `HasData`. The repository does not include automated tests.
