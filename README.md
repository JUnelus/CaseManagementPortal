# Case Management Portal

The **Case Management Portal** is a web-based application built using .NET Core MVC, C#, SQL Server, and Web API. It simulates a system for managing client cases for benefits such as Food Assistance. The system supports basic CRUD (Create, Read, Update, Delete) operations for clients and their associated cases.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features
- Manage client records (create, view, edit, delete).
- Manage case records for each client.
- Recertification tracking for each case.
- RESTful API for interacting with the system programmatically.

## Technologies
- **Backend**: ASP.NET Core MVC, C#, Entity Framework Core
- **Database**: SQL Server (using LocalDB)
- **Frontend**: Bootstrap (auto-generated views)
- **API**: RESTful Web API (JSON)
- **Tools**: Visual Studio, Postman (for API testing)

## Setup

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or LocalDB, which is included with Visual Studio)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or any other IDE supporting .NET Core)
- [Postman](https://www.postman.com/) for testing the Web API

### Steps to Run the Project
1. **Clone the repository**:
   ```bash
   git clone https://github.com/JUnelus/CaseManagementPortal.git
   cd CaseManagementPortal
   ```

2. **Open the project in Visual Studio**:
   - Launch Visual Studio and open the `.sln` solution file from the project directory.

3. **Update `appsettings.json`**:
   - Ensure the connection string in `appsettings.json` is correctly configured for your SQL Server instance (e.g., LocalDB or SQL Server):
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=CaseManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

4. **Run Entity Framework Migrations**:
   - Open the **Package Manager Console** in Visual Studio (Tools -> NuGet Package Manager -> Package Manager Console).
   - Run the following commands to create the database:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

5. **Run the application**:
   - Press `F5` or click the **Run** button in Visual Studio to launch the application using IIS Express.

6. **Access the Application**:
   - The application should open in your default browser at `https://localhost:[port]`. Replace `[port]` with the actual port number.

## Usage

### Web Interface 
- Navigate to `/Clients` to manage clients.
- Navigate to `/Cases` to manage cases.

### API Documentation

#### Base URL
```
https://localhost:[port]/api
```

#### Endpoints

1. **GET all cases**
   - **Method**: `GET`
   - **URL**: `/api/CaseApi`
   - **Description**: Fetches all cases.

2. **GET a specific case**
   - **Method**: `GET`
   - **URL**: `/api/CaseApi/{id}`
   - **Description**: Fetches details of a specific case.

3. **POST a new case**
   - **Method**: `POST`
   - **URL**: `/api/CaseApi`
   - **Description**: Creates a new case.
   - **Body** (JSON):
     ```json
     {
       "caseType": "Food Assistance",
       "caseOpenDate": "2024-10-01T00:00:00",
       "caseStatus": "Open",
       "clientId": 1
     }
     ```

4. **PUT (Update) an existing case**
   - **Method**: `PUT`
   - **URL**: `/api/CaseApi/{id}`
   - **Description**: Updates an existing case.
   - **Body** (JSON):
     ```json
     {
       "caseId": 1,
       "caseType": "Food Assistance",
       "caseOpenDate": "2024-10-01T00:00:00",
       "caseStatus": "Closed",
       "clientId": 1
     }
     ```

5. **DELETE a case**
   - **Method**: `DELETE`
   - **URL**: `/api/CaseApi/{id}`
   - **Description**: Deletes a case.

### Project Structure

```bash
CaseManagementPortal/
│
├── Controllers/         # MVC and API Controllers
│   ├── CaseController.cs
│   ├── ClientController.cs
│   ├── RecertificationController.cs
│   └── CaseApiController.cs
│
├── Models/              # Data Models
│   ├── Case.cs
│   ├── Client.cs
│   └── Recertification.cs
│
├── Data/                # Database Context
│   └── ApplicationDbContext.cs
│
├── Views/               # Razor Views for Clients, Cases, Recertifications
│
├── wwwroot/             # Static files (CSS, JS)
│
├── appsettings.json     # Configuration file
├── CaseManagementPortal.sln # Solution file
└── README.md            # Project documentation (this file)
```

## Contributing

1. Fork the repository.
2. Create a feature branch: `git checkout -b my-feature-branch`
3. Commit your changes: `git commit -m 'Add some feature'`
4. Push to the branch: `git push origin my-feature-branch`
5. Open a pull request.
