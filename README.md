Venta - AutoRepuestos

Este está diseñado para gestionar el proceso principal de ventas de una tienda de repuestos para autos. 
Incluye la gestión de clientes, productos, ventas y detalle de ventas (VentaItem). 
Está desarrollado con .NET 8 Web API, Entity Framework Core y sigue **Clean Architecture**.
-----------------------------------------------------------------------------------------
## Tecnologías

- .NET 8 Web API
- Entity Framework Core
- C#
- SQL Server 2022
- AutoMapper
- Clean Architecture (Domain, Application, Infrastructure, WebApi)
- Swagger para documentación y pruebas
- 
## Estructura del proyecto
AutoRepuestos
│
├── Domain
│   ├── Entities
│   └── Interfaces
│
├── Application
│   ├── DTOs
│   ├── Mapping
│   └── UseCases
│
├── Infrastructure
│   ├── Data
│   └── Repositories
│
└── WebApi
    ├── Controllers
    └── Program.cs
--------------------------------------------------------------------------
--------------------------------------------------------------------------
## Endpoints

### Cliente
- **GET** `/api/Cliente` → Lista todos los clientes
- **GET** `/api/Cliente/{id}` → Obtiene cliente por ID
- **POST** `/api/Cliente` → Crea un cliente

### Producto
- **GET** `/api/Producto` → Lista todos los productos
- **GET** `/api/Producto/{id}` → Obtiene producto por ID
- **POST** `/api/Producto` → Crea un producto

### Venta
- **GET** `/api/Venta` → Lista todas las ventas
- **GET** `/api/Venta/{id}` → Obtiene venta por ID
- **POST** `/api/Venta` → Crea una venta y actualiza stock automáticamente

### VentaItem
- **GET** `/api/VentaItem` → Lista todos los detalles de venta
- **GET** `/api/VentaItem/{id}` → Obtiene detalle por ID
- **POST** `/api/VentaItem` → Crea un detalle de venta
--------------------------------------------------------------------------
--------------------------------------------------------------------------
##  Configuración de la base de datos

```markdown
## Configuración de la base de datos
- Base de datos: `AutoRepuestos` en SQL Server
- Cadena de conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=TU_SERVIDOR;Initial Catalog=AutoRepuestos;Integrated Security=True;Trust Server Certificate=True"
}
Migraciones:
--Add-Migration inicio
--Update-Database
----------------------------------
---------------------------------
## Notas finales / Observaciones
## Observaciones

- Implementa Clean Architecture con separación de capas: Domain, Application, Infrastructure, WebApi.
- La lógica de negocio principal (registrar venta y actualizar stock) se encuentra en `CrearVenta`.
- AutoMapper se utiliza para convertir entre entidades y DTOs.
- Las operaciones POST devuelven 200 OK con mensaje o 201 Created.

