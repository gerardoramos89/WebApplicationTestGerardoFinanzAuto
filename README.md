# CRUD de Estudiantes

Este proyecto es una aplicación **ASP.NET Core** que implementa un CRUD para la tabla de estudiantes. Incluye la funcionalidad de paginación en el endpoint GET para facilitar la gestión de grandes volúmenes de datos.

---

## 📂 Archivos importantes

1. **`SQL_Estudents.sql`**  
   Contiene el script SQL para crear la tabla `Students` en la base de datos. Este archivo incluye las definiciones de las columnas necesarias para ejecutar correctamente el CRUD.  

   **Pasos para usarlo:**
   - Abra su herramienta de gestión de bases de datos (por ejemplo, SQL Server Management Studio o pgAdmin).
   - Ejecute el contenido del archivo `SQL_Estudents.sql` para crear la tabla en su base de datos.

2. **`appsettings.json`**  
   Este archivo contiene la configuración de conexión a la base de datos.  

   - Localice la sección `ConnectionStrings` en el archivo `appsettings.json`.  
   - Asegúrese de actualizar la conexión `DefaultConnection` con las credenciales de su base de datos.

   **Ejemplo:**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SU_SERVIDOR;Database=SU_BASE_DE_DATOS;User Id=SU_USUARIO;Password=SU_CONTRASEÑA;"
   }


![image](https://github.com/user-attachments/assets/67a3b3cc-1f8d-41c8-a866-552c0c66ed90)
