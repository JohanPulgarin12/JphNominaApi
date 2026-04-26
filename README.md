Link sobre la documentación y todo lo relacionado a la base de datos ( https://sistemasentrysas-my.sharepoint.com/my?csf=1&web=1&e=hjRFgG&id=%2Fpersonal%2Fjohan%5Fpulgarin%5Fsistemasentry%5Fcom%5Fco%2FDocuments%2FDocumentaci%C3%B3n%20y%20base%20de%20datos&FolderCTID=0x01200032C478E738A8F3478156FC39E83C5E70 )
- 
1. Requisitos Previos

Antes de ejecutar el sistema, asegúrate de tener:

Node.js 18+
.NET 8
SQL Server
NPM o Yarn
Vite (opcional, se instala automáticamente)

2. Instalación del Backend (API .NET)
2.1. Crear Base de Datos
2.2. Crear Tablas
2.3. Crear Stored Procedures
2.4. Configurar API URL

   En Visual Studio:

Seleccionar proyecto API como Startup Project
Presionar F5
Abrir Swagger en:
https://localhost:44391/swagger/index.html

3. Instalación del Frontend (React + TypeScript)
   3.1. Instalar dependencias
   npm install
   3.2. Ejecutar la aplicación
   npm run dev
   Abrir en:
   http://localhost:5173

   4. Pruebas Manuales
4.1. Probar API en Swagger

En:
https://localhost:44391/swagger/index.html


Probar:
POST /api/States/PostState → Crear estado
GET /api/States/GetStates → Listar
POST /api/Tasks/PostTasks → Crear tarea
GET /api/Tasks/GetTaskById/{id} → Obtener
GET /api/Tasks/GetTasks → Filtrar + paginar
PATCH /api/Tasks/UpdateTask → Editar
DELETE /api/Tasks/DeleteTask?id=1 → Eliminar

4.2. Probar en el frontend

/tasks → Listado completo
Filtros: título, estado, fecha
Crear tarea: /tasks/new
Editar tarea: /tasks/{id}
CRUD de estados en /states
