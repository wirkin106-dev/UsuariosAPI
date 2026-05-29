# UsuariosAPI 🚀

API REST desarrollada con **ASP.NET Core** y **Entity Framework Core** para gestionar usuarios en una base de datos. Permite realizar operaciones CRUD completas con validación de correos duplicados.

---

## 🛠️ Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Swagger (OpenAPI)

---

## 📁 Estructura del proyecto

```
UsuariosAPI/
├── Controllers/
│   └── UsuariosController.cs     → Recibe y responde las solicitudes HTTP
├── Data/
│   └── AppDbContext.cs           → Contexto de base de datos
├── DTOs/
│   └── UsuarioDto.cs             → Datos que entran y salen de la API
├── Models/
│   └── Usuario.cs                → Modelo de datos (entidad)
├── Repositories/
│   ├── IUsuarioRepository.cs     → Interfaz del repositorio
│   └── UsuarioRepository.cs      → Acceso a la base de datos
├── Services/
│   ├── IUsuarioService.cs        → Interfaz del servicio
│   └── UsuarioService.cs         → Lógica de negocio
├── appsettings.json              → Configuración y cadena de conexión
└── Program.cs                    → Configuración de la aplicación
├──- images/                      → Capturas de pantalla de las pruebas
```

---

## ✅ Buenas prácticas aplicadas

### Principios SOLID
- **S - Single Responsibility**: Cada clase tiene una sola responsabilidad. El controlador solo maneja HTTP, el servicio maneja la lógica y el repositorio maneja la base de datos.
- **O - Open/Closed**: Se puede extender el comportamiento sin modificar el código existente gracias a las interfaces.
- **D - Dependency Inversion**: Las clases dependen de interfaces, no de implementaciones concretas.

### Arquitectura en capas
- **Controller** → Solo recibe peticiones HTTP y devuelve respuestas
- **Service** → Contiene la lógica de negocio (validar correo duplicado, etc.)
- **Repository** → Solo se comunica con la base de datos
- **DTO** → Controla qué datos entran y salen de la API

### Otras prácticas
- **Alta cohesión**: Cada clase hace solo lo que le corresponde
- **Bajo acoplamiento**: Las capas se comunican a través de interfaces
- **DTOs**: Se usan para no exponer directamente el modelo de la base de datos
- **Manejo de excepciones**: Respuestas claras con códigos HTTP correctos (200, 201, 400, 404)
- **Índice único en Correo**: Garantiza que no existan correos duplicados a nivel de base de datos

---

## ⚙️ Requisitos para ejecutar

- Visual Studio 2022 o superior
- .NET 10 SDK
- SQL Server Express o LocalDB (viene con Visual Studio)
- SQL Server Management Studio (opcional, para ver la BD)

---

## 🚀 Instrucciones para ejecutar

### 1. Clonar el repositorio
```bash
git clone https://github.com/TU_USUARIO/UsuariosAPI.git
cd UsuariosAPI
```

### 2. Configurar la cadena de conexión
En el archivo `appsettings.json` verifica que la cadena de conexión sea correcta:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Crear la base de datos
Abre la **Consola del Administrador de paquetes** en Visual Studio y ejecuta:
```
Update-Database
```
Esto creará automáticamente la base de datos `UsuariosDB` con la tabla `Usuarios`.

### 4. Ejecutar la API
Presiona **F5** o el botón ▶ en Visual Studio. Se abrirá automáticamente Swagger en el navegador.

### 5. Acceder a Swagger
```
https://localhost:7023/swagger
```

---

## 📋 Endpoints disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/usuarios` | Obtener todos los usuarios |
| GET | `/api/usuarios/{id}` | Obtener un usuario por ID |
| POST | `/api/usuarios` | Crear un nuevo usuario |
| PUT | `/api/usuarios/{id}` | Actualizar un usuario existente |
| DELETE | `/api/usuarios/{id}` | Eliminar un usuario por ID |

---

## 🧪 Cómo probar con Swagger

### Crear un usuario (POST)
1. Click en **POST /api/usuarios**
2. Click en **Try it out**
3. Pega el siguiente JSON en el body:
```json
{
  "nombre": "Juan Perez",
  "correo": "juan@gmail.com",
  "fechaDeNacimiento": "2000-01-15T00:00:00"
}
```
4. Click en **Execute**
5. Respuesta esperada: **201 Created**

### Obtener todos los usuarios (GET)
1. Click en **GET /api/usuarios**
2. Click en **Try it out**
3. Click en **Execute**
4. Respuesta esperada: **200 OK**

### Obtener usuario por ID (GET)
1. Click en **GET /api/usuarios/{id}**
2. Click en **Try it out**
3. Escribe el ID en el campo **id**
4. Click en **Execute**
5. Respuesta esperada: **200 OK** o **404** si no existe

### Actualizar un usuario (PUT)
1. Click en **PUT /api/usuarios/{id}**
2. Click en **Try it out**
3. Escribe el ID a actualizar
4. Pega el JSON con los nuevos datos
5. Click en **Execute**
6. Respuesta esperada: **200 OK**

### Eliminar un usuario (DELETE)
1. Click en **DELETE /api/usuarios/{id}**
2. Click en **Try it out**
3. Escribe el ID a eliminar
4. Click en **Execute**
5. Respuesta esperada: **200 OK**

### Validación de correo duplicado
Si intentas crear un usuario con un correo que ya existe:
- Respuesta: **400 Bad Request**
- Mensaje: `"El correo electrónico ya está en uso."`

---

## 📸 Capturas de pantalla

### POST - Crear usuario (201 Created)
![POST Crear usuario](images/post-crear-usuario.jfif)

### GET - Obtener todos los usuarios (200 OK)
![GET Todos los usuarios](images/get-todos-usuarios.jfif)

### GET - Obtener usuario por ID (200 OK)
![GET Usuario por ID](images/get-usuario-id.jfif)

### PUT - Actualizar usuario (200 OK)
![PUT Actualizar usuario](images/put-actualizar-usuario.jfif)

### DELETE - Eliminar usuario (200 OK)
![DELETE Eliminar usuario](images/delete-eliminar-usuario.jfif)

### POST - Validación correo duplicado (400 Bad Request)
![POST Correo duplicado](images/post-correo-duplicado.jfif)

---

## 👨‍💻 Autor
Wirkin Alexi Montero Vásquez 