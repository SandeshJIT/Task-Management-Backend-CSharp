# Task Management Backend CSharp

## Overview

**Task Management Backend CSharp** is a C# project designed to handle CRUD (Create, Read, Update, Delete) operations for managing a task list. The project utilizes Entity Framework Core for database operations, Fluent Validations for input validation, and Swagger for API documentation. Comprehensive unit tests are included to ensure the robustness of the application.

## Features

- **CRUD Operations**: Manage tasks with full CRUD functionality.
- **Entity Framework Core**: Integration with EF Core for database interactions.
- **Fluent Validations**: Input validations using FluentValidation.
- **Swagger Documentation**: Auto-generated API documentation using Swagger.
- **Unit Testing**: Comprehensive unit tests to ensure code quality and reliability.


## Getting Started

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/SandeshJIT/Task-Management-Backend-CSharp.git

2.Navigate to the src directory:
      ```bash
      cd Task-Management-Backend-CSharp/src
      ```

3.Install the required dependencies (assuming you have .NET SDK installed):
   ```bash
   dotnet restore
   ```

4. Download SQL LocalDB:
SQL Server Express LocalDB is a lightweight version of SQL Server that’s ideal for development and testing. You can download it from the official Microsoft website: SQL Server Express LocalDB.
Install Entity Framework Core (EF Core):
EF Core is shipped as NuGet packages. To add EF Core to your application, install the NuGet package for the database provider you want to use. Since this project uses SQL Server, install the SQL Server provider package:
Using .NET Core CLI:
    ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    ```

5. Using Visual Studio NuGet Package Manager Console:
    ```bash
   Install-Package Microsoft.EntityFrameworkCore.SqlServer
    ```
7. Run the migrations to set up the database:
    ```bash
   dotnet ef database update
    ```
## Usage

## Project Structure
Todo.Api: This is the API project and serves as the startup project.
Todo.UnitTests: Includes unit tests for the application.

### Endpoints

- **GET** `/todos`: Get a list of all todo items.
- **POST** `/todos`: Create a new todo item.
- **GET** `/todos/:id`: Get details of a specific todo item.
- **DELETE** `/todos/:id`: Delete a specific todo item.

## Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.
