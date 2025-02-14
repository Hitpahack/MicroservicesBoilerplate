# Microservices Architecture with .NET 8, C#, and MongoDB

## 📌 Project Overview
This project demonstrates a microservices architecture using .NET 8, C#, and MongoDB. It includes multiple independent services that communicate via REST APIs and RabbitMQ for event-driven messaging.

## 🚀 Features
- ✅ **Microservices-based architecture**
- ✅ **REST API communication between services**
- ✅ **Event-driven communication using RabbitMQ**
- ✅ **MongoDB for NoSQL data storage**
- ✅ **Entity Framework Core for SQL-based microservices**
- ✅ **Docker support for containerized deployment**
- ✅ **Swagger API documentation**
- ✅ **Authentication & Authorization using JWT**

## 🛠️ Tech Stack
![Tech Stack](https://your-image-link.com/tech-stack-overview.png)
- **Backend:** .NET 8, C#
- **Database:** MongoDB, SQL Server
- **API Gateway:** Ocelot
- **Message Broker:** RabbitMQ
- **Authentication:** JWT
- **Containerization:** Docker
- **Monitoring:** Prometheus & Grafana

## 🏗️ Microservices Architecture
📂 **OrderService** - Manages orders and integrates with PaymentService.
📂 **PaymentService** - Handles payment processing and communicates with OrderService.
📂 **InventoryService** - Manages stock availability.
📂 **Gateway (Ocelot)** - API Gateway to route requests.

### 📁 Folder Structure
```
📂 OrderService
 ├── 📂 Controllers
 ├── 📂 Models
 ├── 📂 Services
 ├── 📂 Data
 ├── 📂 DTOs
 ├── 📂 Middleware
 ├── 📂 Config
 ├── 📄 Program.cs
 ├── 📄 appsettings.json
```

## 🔧 Setup & Installation
### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-repo/microservices-dotnet.git
cd microservices-dotnet
```

### 2️⃣ Install Dependencies
```bash
dotnet restore
```

### 3️⃣ Setup MongoDB & SQL Server
- Install [MongoDB](https://www.mongodb.com/try/download/community)
- Configure SQL Server connection in `appsettings.json`

### 4️⃣ Run Migrations (For SQL Services)
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Run the Microservices
```bash
dotnet run --project OrderService
```
Repeat the above command for all microservices.

### 6️⃣ Docker Support (Optional)
To run all services using Docker Compose:
```bash
docker-compose up --build
```

## 📌 API Endpoints
### 📍 OrderService
| Method | Endpoint | Description |
|--------|---------|-------------|
| GET | `/api/orders` | Fetch all orders |
| GET | `/api/orders/{id}` | Fetch a specific order |
| POST | `/api/orders` | Create a new order |

### 📍 PaymentService
| Method | Endpoint | Description |
|--------|---------|-------------|
| POST | `/api/payment/process` | Process payment |

## 🛠️ Communication Between Microservices
### 1️⃣ REST API Communication
- OrderService calls PaymentService via HTTP.
- Implemented using Refit:
```csharp
[Post("/api/payment/process")]
Task<PaymentResponse> ProcessPayment([Body] PaymentRequest request);
```

### 2️⃣ Event-Driven Communication (RabbitMQ)
- OrderService publishes events when an order is created.
- PaymentService listens to order events and processes payments.

## 🔥 Monitoring & Logging
- **Prometheus** for metrics collection.
- **Grafana** for visualization.
- **Serilog** for structured logging.

## 📜 License
This project is licensed under the MIT License.

## ✨ Contributing
Contributions are welcome! Feel free to fork, open issues, or submit PRs.

## 📞 Contact
For any questions, reach out at [your-email@example.com](mailto:your-email@example.com).

---

### 🎉 Happy Coding! 🚀

