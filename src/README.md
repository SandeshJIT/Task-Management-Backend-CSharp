# Todo-Backend

Welcome to the Todo-Backend project! This repository serves as an example of a simple backend application for managing todo items. It is built using .NET and EF Core.

## Getting Started

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/SandeshJIT/Todo-Backend.git

2.Navigate to the src directory:
      ```bash
      cd Todo-Backend/src
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

Project Structure
Todo.Api: This is the API project and serves as the startup project.
Todo.UnitTests: Includes unit tests for the application.
API Endpoints
GET /api/todo-list/task: Get a list of all todo items.
POST /api/todo-list/task: Create a new todo item.
GET /api/todo-list/task/:id: Get details of a specific todo item.

Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.

License
This project is licensed under the MIT License. See the LICENSE file for details.

