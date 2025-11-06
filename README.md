# TechAssignment

## 🧩 Components

### **TechAssignment.JsonWriteLine**
A helper that prints JSON strings in a human-readable (pretty-printed) format using `Console.WriteLine`.

**Example:**
JsonWriteLine("{\"name\":\"John\",\"age\":30}");
Output:
{
  "name": "John",
  "age": 30
}

### **TechAssignment.TokenValidationService**

A service that:

Verifies user credentials against the database
Validates JWT tokens using RSA public keys (res/public.pem)
Used by the middleware and controllers to ensure requests are authorized.

Running the Database (PostgreSQL via Docker)
docker build -t auth-db .
docker run --rm -d --name auth-db-cont -p 5432:5432 -v pgdata:/var/lib/postgresql/18 auth-db
