# Product API

**Product API** — демонстраційний RESTful Web API на **ASP.NET Core (.NET 8)** з повним CRUD для роботи з продуктами.  
Проєкт побудований з використанням **Entity Framework Core**, **SQL Server**, **Swagger** та **Docker**, демонструє базовий, але наближений до реальності підхід до розробки та контейнеризації Web API.

Репозиторій призначений для:
- навчання та демо ASP.NET Core Web API
- прикладів роботи з EF Core та SQL Server
- демонстрації запуску застосунку через **Docker Compose**
- використання Swagger для документації API

---

## 🛠️ Features

- CRUD для продуктів (`Product`):
  - `Id` – int
  - `Name` – string
  - `Price` – decimal
- Swagger/OpenAPI документація
- Entity Framework Core + SQL Server
- Docker / Docker Compose підтримка

---

## ▶️ API Endpoints

| Method | URL | Description |
|--------|-----|------------|
| GET    | `/api/products` | Отримати всі продукти |
| GET    | `/api/products/{id}` | Отримати продукт по ID |
| POST   | `/api/products` | Створити продукт |
| PUT    | `/api/products/{id}` | Оновити продукт |
| DELETE | `/api/products/{id}` | Видалити продукт |

Swagger UI доступний за адресою:

http://localhost:5000/swagger

## ▶️ Run API container manually

docker run -p 5000:5000 \
-e ConnectionStrings__DefaultConnection="Server=host.docker.internal,1433;Database=ProductDb;User Id=sa;Password=Strong_Passw0rd!;TrustServerCertificate=True" \
productapi

4️⃣ View logs

API logs:

docker logs productapi

Using Docker Compose:

docker compose logs productapi

5️⃣ SQL Server (Docker)

Start only SQL Server container:

docker compose up sqlserver

Connect to SQL Server container:

docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd \
  -S localhost -U sa -P Strong_Passw0rd!

⚙️ Configuration

API expects connection string via environment variable:

ConnectionStrings__DefaultConnection

Example:

Server=sqlserver,1433;
Database=ProductDb;
User Id=sa;
Password=Strong_Passw0rd!;
TrustServerCertificate=True

🧪 Example API request (POST)
POST /api/products
{
  "name": "Laptop",
  "price": 1200.50
}