Microservices Architecture with .NET 8, C#, and SQL Server

📌 Project Overview

This project demonstrates a microservices-based architecture using ASP.NET Core Web API with .NET 8. The system consists of multiple microservices, including OrderService and PaymentService, which communicate with each other using REST APIs and an event-driven approach.

🏗 Tech Stack

Backend: .NET 8, C#

Database: SQL Server, MongoDB (optional)

API Communication: REST API, Refit

ORM: Entity Framework Core

Dependency Injection: Built-in .NET DI

Testing & Documentation: Swagger (Swashbuckle.AspNetCore)

Message Broker (Optional): RabbitMQ

📂 Project Structure

📂 MicroservicesProject
  ├── 📂 OrderService
  │   ├── 📂 Controllers
  │   ├── 📂 Models
  │   ├── 📂 Services
  │   ├── 📂 Data (Entity Framework Core)
  │   ├── 📂 DTOs (Data Transfer Objects)
  │   ├── 📄 Program.cs
  │   ├── 📄 appsettings.json
  ├── 📂 PaymentService
  │   ├── 📂 Controllers
  │   ├── 📂 Models
  │   ├── 📂 Services
  │   ├── 📂 Data
  │   ├── 📂 DTOs
  │   ├── 📄 Program.cs
  │   ├── 📄 appsettings.json

🚀 Setup & Installation

Prerequisites

Install .NET 8 SDK

Install SQL Server

Install MongoDB (if required)

Install Visual Studio 2022 (or any compatible IDE)

1️⃣ Clone the Repository

git clone https://github.com/yourusername/MicroservicesProject.git
cd MicroservicesProject

2️⃣ Setup Database Connection

Modify the appsettings.json in each microservice to configure the database connection.

Example for OrderService:

"ConnectionStrings": {
  "OrderDb": "Server=localhost;Database=OrderDb;Trusted_Connection=True;"
}

Example for PaymentService:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=PaymentDB;User Id=sa;Password=yourpassword;TrustServerCertificate=True;"
}

3️⃣ Install Required Packages

Run the following command in each microservice directory:

dotnet restore

4️⃣ Run Migrations & Update Database

dotnet ef migrations add InitialCreate
dotnet ef database update

5️⃣ Start Microservices

Run each microservice separately:

dotnet run --project OrderService

dotnet run --project PaymentService

🛠 API Endpoints

OrderService

GET /api/orders → Fetch all orders

GET /api/orders/{id} → Fetch a specific order

POST /api/orders → Create a new order

PaymentService

POST /api/payment/process → Process a payment

🔗 Communication Between Microservices

Synchronous: REST API calls using Refit

Asynchronous (Optional): Event-driven communication using RabbitMQ

🔍 Testing

You can test the API endpoints using Postman or Swagger.

Swagger URL: https://localhost:5001/swagger/index.html

📜 License

This project is licensed under the MIT License - see the LICENSE file for details.

👨‍💻 Developed by [Your Name] | 📧 Contact: your.email@example.com

