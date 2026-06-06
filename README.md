# UsuariosAPI 🚀

API REST desarrollada con **ASP.NET Core** y **Entity Framework Core** para gestionar usuarios en una base de datos. Permite realizar operaciones CRUD completas con validación de correos duplicados y autenticación segura mediante **JSON Web Tokens (JWT)**.

---

## 🛠️ Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Scalar (OpenAPI - interfaz moderna para .NET 10)
- JWT (JSON Web Tokens)
- SHA-256 (encriptación de contraseñas)

---

## 📁 Estructura del proyecto

```
UsuariosAPI/
├── Controllers/
│   ├── AuthController.cs         → Endpoints de autenticación JWT
│   └── UsuariosController.cs     → Recibe y responde las solicitudes HTTP
├── Data/
│   └── AppDbContext.cs           → Contexto de base de datos
├── DTOs/
│   ├── LoginDto.cs               → Datos para iniciar sesión
│   ├── RefreshDto.cs             → Datos para refrescar el token
│   └── UsuarioDto.cs             → Datos que entran y salen de la API
├── Models/
│   └── Usuario.cs                → Modelo de datos (entidad)
├── Repositories/
│   ├── IUsuarioRepository.cs     → Interfaz del repositorio
│   └── UsuarioRepository.cs      → Acceso a la base de datos
├── Services/
│   ├── IUsuarioService.cs        → Interfaz del servicio
│   └── UsuarioService.cs         → Lógica de negocio
├── images/                       → Capturas de pantalla de las pruebas
├── appsettings.json              → Configuración, cadena de conexión y JWT
└── Program.cs                    → Configuración de la aplicación
```

---

## ✅ Buenas prácticas aplicadas

### Principios SOLID
- **S - Single Responsibility**: Cada clase tiene una sola responsabilidad. El controlador solo maneja HTTP, el servicio maneja la lógica y el repositorio maneja la base de datos.
- **O - Open/Closed**: Se puede extender el comportamiento sin modificar el código existente gracias a las interfaces.
- **D - Dependency Inversion**: Las clases dependen de interfaces, no de implementaciones concretas.

### Arquitectura en capas
- **Controller** → Solo recibe peticiones HTTP y devuelve respuestas
- **Service** → Contiene la lógica de negocio (validar correo duplicado, encriptar contraseña, etc.)
- **Repository** → Solo se comunica con la base de datos
- **DTO** → Controla qué datos entran y salen de la API

### Otras prácticas
- **Alta cohesión**: Cada clase hace solo lo que le corresponde
- **Bajo acoplamiento**: Las capas se comunican a través de interfaces
- **DTOs**: Se usan para no exponer directamente el modelo de la base de datos
- **Manejo de excepciones**: Respuestas claras con códigos HTTP correctos (200, 201, 400, 401, 404)
- **Índice único en Correo**: Garantiza que no existan correos duplicados a nivel de base de datos
- **DataAnnotations**: Validaciones en los modelos con `[Required]`, `[MaxLength]`, `[MinLength]`, `[EmailAddress]`
- **Seguridad JWT**: Tokens con claims, fecha de expiración y firma HMAC-SHA256
- **Encriptación SHA-256**: Las contraseñas nunca se guardan en texto plano

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
git clone https://github.com/wirkin106-dev/UsuariosAPI.git
cd UsuariosAPI
```

### 2. Configurar la cadena de conexión y JWT
En el archivo `appsettings.json` verifica que la configuración sea correcta:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "EstaClaveSuperSecretaDebeSerLarga32Caracteres!",
    "Issuer": "UsuariosAPI",
    "Audience": "UsuariosAPIClientes",
    "ExpirationMinutes": 60
  }
}
```

### 3. Crear la base de datos
Abre la **Consola del Administrador de paquetes** en Visual Studio y ejecuta:
```
Update-Database
```
Esto creará automáticamente la base de datos `UsuariosDB` con la tabla `Usuarios` incluyendo la columna `Password`.

### 4. Ejecutar la API
Presiona **F5** o el botón ▶ en Visual Studio.

### 5. Acceder a Scalar (interfaz visual)
```
https://localhost:7023/scalar/v1
```

---

## 📋 Endpoints disponibles

### 🔓 Autenticación (públicos)
| Método | Ruta | Descripción |
|--------|------|-------------|
| POST | `/api/auth/login` | Iniciar sesión y obtener token JWT |
| POST | `/api/auth/refresh` | Renovar el token JWT |

### 🔒 Usuarios (requieren token JWT)
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/usuarios` | Obtener todos los usuarios |
| GET | `/api/usuarios/{id}` | Obtener un usuario por ID |
| POST | `/api/usuarios` | Crear un nuevo usuario |
| PUT | `/api/usuarios/{id}` | Actualizar un usuario existente |
| DELETE | `/api/usuarios/{id}` | Eliminar un usuario por ID |

---

## 🧪 Cómo probar con Scalar

### Paso 1 - Crear un usuario (POST)
1. Click en **Usuarios** → **POST /api/usuarios** → **Test Request**
2. Pega el siguiente JSON en el body:
```json
{
  "nombre": "Juan Perez",
  "correo": "juan@gmail.com",
  "fechaDeNacimiento": "2000-01-15T00:00:00",
  "password": "123456"
}
```
3. Click en **Send**
4. Respuesta esperada: **201 Created**

### Paso 2 - Iniciar sesión (POST Login)
1. Click en **Auth** → **POST /api/auth/login** → **Test Request**
2. Pega el siguiente JSON:
```json
{
  "correo": "juan@gmail.com",
  "password": "123456"
}
```
3. Click en **Send**
4. Respuesta esperada: **200 OK** con el token JWT

### Paso 3 - Usar el token en endpoints protegidos
1. Copia el valor del campo `token` de la respuesta del login
2. Click en cualquier endpoint de Usuarios → **Test Request**
3. En **Headers** agrega:
   - **Key**: `Authorization`
   - **Value**: `Bearer {pega aquí tu token}`
4. Click en **Send**
5. Respuesta esperada: **200 OK**

### Paso 4 - Probar sin token (debe dar 401)
1. Click en **GET /api/usuarios** → **Test Request**
2. Sin agregar ningún header
3. Click en **Send**
4. Respuesta esperada: **401 Unauthorized**

### Paso 5 - Refrescar el token (POST Refresh)
1. Click en **Auth** → **POST /api/auth/refresh** → **Test Request**
2. Pega el siguiente JSON con tu token actual:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```
3. Click en **Send**
4. Respuesta esperada: **200 OK** con nuevo token

### Validación de correo duplicado
Si intentas crear un usuario con un correo que ya existe:
- Respuesta: **400 Bad Request**
- Mensaje: `"El correo electrónico ya está en uso."`

---

## 📸 Capturas de pantalla

### Tarea 5 - CRUD básico

#### POST - Crear usuario (201 Created)
![POST Crear usuario](images/post-crear-usuario.jfif)

#### GET - Obtener todos los usuarios (200 OK)
![GET Todos los usuarios](images/get-todos-usuarios.jfif)

#### GET - Obtener usuario por ID (200 OK)
![GET Usuario por ID](images/get-usuario-id.jfif)

#### PUT - Actualizar usuario (200 OK)
![PUT Actualizar usuario](images/put-actualizar-usuario.jfif)

#### DELETE - Eliminar usuario (200 OK)
![DELETE Eliminar usuario](images/delete-eliminar-usuario.jfif)

#### POST - Validación correo duplicado (400 Bad Request)
![POST Correo duplicado](images/post-correo-duplicado.jfif)

### Tarea 6 - Autenticación JWT

#### POST - Login (200 OK con token JWT)
![POST Login](images/post-login.jfif)

#### GET - Sin token (401 Unauthorized)
![GET Sin token](images/get-sin-token.jfif)

#### GET - Con token (200 OK)
![GET Con token](images/get-con-token.jfif)

#### POST - Refresh token (200 OK)
![POST Refresh](images/post-refresh.jfif)

---

## 👨‍💻 Autor
Wirkin Alexi Montero Vásquez
