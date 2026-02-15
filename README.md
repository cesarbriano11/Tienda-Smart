sistema de gestion de sucursales TiendaSmart

- Backend: ASP.NET Core Web API
- Frontend: Angular
- Base de Datos: SQL Server

Base de datos
1. Abrir SQL Server Management Studio.
2. Abrir el archivo
3. Ejecutar el script completo.

Conexion a la base desde el back
1. Ir a la carpeta:
Backend/
2. Abrir el archivo:
appsettings.json
3. Modificar la cadena de conexion si tu servidor es diferente:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVER;Database=DB_TIENDA;Trusted_Connection=True;TrustServerCertificate=True;"
}

Creado por: Cesar Agustin Briano Aviles

