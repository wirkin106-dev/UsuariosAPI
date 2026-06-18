# UsuariosAPI 🚀

API REST desarrollada con **ASP.NET Core** y **Entity Framework Core** para gestionar usuarios, productos, categorías y proveedores. Incluye autenticación segura mediante **JSON Web Tokens (JWT)**, operaciones de agregación con LINQ y un sistema de logs en archivo JSON.

---

## 🛠️ Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server / LocalDB
- Scalar (OpenAPI - interfaz moderna para .NET 10)
- Swagger UI (documentación clásica)
- JWT (JSON Web Tokens)
- SHA-256 (encriptación de contraseñas)
- LINQ / Expresiones Lambda
- System.Text.Json (serialización de logs)

---

## 📁 Estructura del proyecto

```
UsuariosAPI/
├── Controllers/
│   ├── AuthController.cs         → Endpoints de autenticación JWT
│   ├── UsuariosController.cs     → CRUD de usuarios + endpoint de logs
│   ├── CategoriasController.cs   → CRUD de categorías
│   ├── ProveedoresController.cs  → CRUD de proveedores
│   └── ProductosController.cs   → CRUD de productos + endpoints especiales
├── Data/
│   └── AppDbContext.cs           → Contexto de base de datos y relaciones
├── DTOs/
│   ├── LoginDto.cs               → Datos para iniciar sesión
│   ├── RefreshDto.cs             → Datos para refrescar el token
│   ├── UsuarioDto.cs             → Datos de usuario
│   ├── CategoriaDto.cs           → Datos de categoría
│   ├── ProveedorDto.cs           → Datos de proveedor
│   ├── ProductoDto.cs            → Datos de producto
│   └── LogEntryDto.cs            → Datos de entrada de log
├── Models/
│   ├── Usuario.cs                → Entidad usuario
│   ├── Categoria.cs              → Entidad categoría
│   ├── Proveedor.cs              → Entidad proveedor
│   └── Producto.cs               → Entidad producto
├── Repositories/
│   ├── IUsuarioRepository.cs     → Interfaz repositorio usuario
│   ├── UsuarioRepository.cs      → Implementación repositorio usuario
│   ├── ICategoriaRepository.cs   → Interfaz repositorio categoría
│   ├── CategoriaRepository.cs    → Implementación repositorio categoría
│   ├── IProveedorRepository.cs   → Interfaz repositorio proveedor
│   ├── ProveedorRepository.cs    → Implementación repositorio proveedor
│   ├── IProductoRepository.cs    → Interfaz repositorio producto
│   └── ProductoRepository.cs    → Implementación repositorio producto
├── Services/
│   ├── IUsuarioService.cs        → Interfaz servicio usuario
│   ├── UsuarioService.cs         → Lógica de negocio usuario + llamada al log
│   ├── ICategoriaService.cs      → Interfaz servicio categoría
│   ├── CategoriaService.cs       → Lógica de negocio categoría
│   ├── IProveedorService.cs      → Interfaz servicio proveedor
│   ├── ProveedorService.cs       → Lógica de negocio proveedor
│   ├── IProductoService.cs       → Interfaz servicio producto
│   ├── ProductoService.cs       → Lógica de negocio producto
│   ├── ILogService.cs            → Interfaz del sistema de logs
│   └── LogService.cs            → Implementación del sistema de logs JSON
├── images/                       → Capturas de pantalla de las pruebas
│   ├── 01_Categorias/
│   ├── 02_Proveedores/
│   ├── 03_Productos/
│   └── 04_Logs/
├── usuarios_log.json             → Archivo de log generado automáticamente
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
- **Service** → Contiene la lógica de negocio
- **Repository** → Solo se comunica con la base de datos
- **DTO** → Controla qué datos entran y salen de la API

### Otras prácticas
- **Alta cohesión**: Cada clase hace solo lo que le corresponde
- **Bajo acoplamiento**: Las capas se comunican a través de interfaces
- **DTOs**: Se usan para no exponer directamente el modelo de la base de datos
- **Manejo de excepciones**: Respuestas claras con códigos HTTP correctos (200, 201, 400, 401, 404)
- **DataAnnotations**: Validaciones con `[Required]`, `[MaxLength]`, `[MinLength]`, `[EmailAddress]`
- **Seguridad JWT**: Tokens con claims, fecha de expiración y firma HMAC-SHA256
- **Encriptación SHA-256**: Las contraseñas nunca se guardan en texto plano
- **IgnoreCycles**: Configuración del serializador JSON para evitar ciclos de referencias en relaciones bidireccionales
- **LINQ**: Consultas eficientes para operaciones de agregación (Max, Min, Sum, Average, Count)
- **Sistema de Logs**: Registro automático en archivo JSON con manejo de errores y validación de nulos

---

## 🔗 Relaciones entre entidades

- Un **Producto** pertenece a una **Categoría**
- Un **Producto** tiene un **Proveedor**
- Un **Proveedor** puede proporcionar varios **Productos**
- Una **Categoría** puede tener varios **Productos**

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

### 4. Ejecutar la API
Presiona **F5** o el botón ▶ en Visual Studio.

### 5. Acceder a Scalar o Swagger
```
https://localhost:7023/scalar/v1
https://localhost:7023/swagger
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
| POST | `/api/usuarios` | Crear un nuevo usuario (genera log automático) |
| PUT | `/api/usuarios/{id}` | Actualizar un usuario existente |
| DELETE | `/api/usuarios/{id}` | Eliminar un usuario |
| GET | `/api/usuarios/logs` | Obtener historial de logs en JSON |

### 🔒 Categorías (requieren token JWT)
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/categorias` | Obtener todas las categorías |
| GET | `/api/categorias/{id}` | Obtener una categoría por ID |
| POST | `/api/categorias` | Crear una nueva categoría |
| PUT | `/api/categorias/{id}` | Actualizar una categoría |
| DELETE | `/api/categorias/{id}` | Eliminar una categoría |

### 🔒 Proveedores (requieren token JWT)
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/proveedores` | Obtener todos los proveedores |
| GET | `/api/proveedores/{id}` | Obtener un proveedor por ID |
| POST | `/api/proveedores` | Crear un nuevo proveedor |
| PUT | `/api/proveedores/{id}` | Actualizar un proveedor |
| DELETE | `/api/proveedores/{id}` | Eliminar un proveedor |

### 🔒 Productos (requieren token JWT)
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/productos` | Obtener todos los productos |
| GET | `/api/productos/{id}` | Obtener un producto por ID |
| POST | `/api/productos` | Crear un nuevo producto |
| PUT | `/api/productos/{id}` | Actualizar un producto |
| DELETE | `/api/productos/{id}` | Eliminar un producto |
| GET | `/api/productos/estadisticas` | Precio más alto, más bajo, suma y promedio |
| GET | `/api/productos/categoria/{id}` | Productos por categoría |
| GET | `/api/productos/proveedor/{id}` | Productos por proveedor |
| GET | `/api/productos/total` | Cantidad total de productos |

---

## 🧪 Cómo probar con Scalar

### Paso 1 - Obtener token JWT
1. Click en **Auth** → **POST /api/auth/login** → **Test Request**
2. Body:
```json
{
  "correo": "wirkin@gmail.com",
  "password": "123456"
}
```
3. Copia el `token` de la respuesta

### Paso 2 - Usar el token
En cada endpoint protegido agrega en **Headers**:
- **Key**: `Authorization`
- **Value**: `Bearer {tu token}`

### Paso 3 - Crear datos de prueba
**Categoría:**
```json
{
  "nombre": "Electrónica"
}
```

**Proveedor:**
```json
{
  "nombre": "TechSupplies",
  "contacto": "contacto@techsupplies.com"
}
```

**Producto:**
```json
{
  "nombre": "Laptop HP",
  "precio": 850.99,
  "stock": 15,
  "idProveedor": 1,
  "idCategoria": 1
}
```

### Paso 4 - Probar el sistema de logs
1. Crea un usuario nuevo con **POST /api/usuarios**
2. El sistema genera automáticamente el log en `usuarios_log.json`
3. Consulta el historial con **GET /api/usuarios/logs**
4. Respuesta esperada: array JSON con los registros

---

## 📸 Capturas de pantalla

### Tarea 5 - CRUD Usuarios

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

---

### Tarea 6 - Autenticación JWT

#### POST - Login (200 OK con token JWT)
<<<<<<< HEAD
![POST Login](images/post-login.jfif)

#### GET - Sin token (401 Unauthorized)
![GET Sin token](images/get-sin-token.jfif)

#### GET - Con token (200 OK)
![GET Con token](images/get-con-token.jfif)

#### POST - Refresh token (200 OK)
![POST Refresh](images/post-refresh.jfif)

---

### Tarea 7 - Productos, Categorías y Proveedores

#### Categorías

##### POST - Crear categoría (201 Created)
![POST Crear categoría](images/01_Categorias/1_4_Categorías.jfif)

##### GET - Obtener todas las categorías (200 OK)
![GET Todas las categorías](images/01_Categorias/2_4_Categorías.jfif)

##### PUT - Actualizar categoría (200 OK)
![PUT Actualizar categoría](images/01_Categorias/3_4_Categorías.jfif)

##### DELETE - Eliminar categoría (200 OK / 404)
![DELETE Eliminar categoría](images/01_Categorias/4_4_Categorías.jfif)

#### Proveedores

##### POST - Crear proveedor (201 Created)
![POST Crear proveedor](images/02_Proveedores/1_4_Proveedores.jfif)

##### GET - Obtener todos los proveedores (200 OK)
![GET Todos los proveedores](images/02_Proveedores/2_4_Proveedores.jfif)

##### PUT - Actualizar proveedor (200 OK)
![PUT Actualizar proveedor](images/02_Proveedores/3_4_Proveedores.jfif)

##### DELETE - Proveedor no encontrado (404 Not Found)
![DELETE Proveedor no encontrado](images/02_Proveedores/4_4_Proveedores.jfif)

#### Productos

##### POST - Crear producto (201 Created)
![POST Crear producto](images/03_Productos/1_4_Productos.jfif)

##### GET - Obtener todos los productos (200 OK)
![GET Todos los productos](images/03_Productos/2_4_Productos.jfif)

##### PUT - Actualizar producto (200 OK)
![PUT Actualizar producto](images/03_Productos/3_4_Productos.jfif)

##### DELETE - Producto no encontrado (404 Not Found)
![DELETE Producto no encontrado](images/03_Productos/4_4_Productos.jfif)

##### GET - Estadísticas de precios
![GET Estadísticas](images/03_Productos/5_4_productos.jfif)

##### GET - Productos por categoría
![GET Por categoría](images/03_Productos/6_4_productos.jfif)

##### GET - Productos por proveedor
![GET Por proveedor](images/03_Productos/7_4_productos.jfif)

##### GET - Total de productos
![GET Total](images/03_Productos/8_4_productos.jfif)

---

### Tarea 8 - Sistema de Logs JSON

#### POST - Crear usuario y generar log automático (201 Created)
![POST Crear usuario con log](images/04_Logs/post-crear-usuario-log.jfif)

#### GET - Historial de logs (200 OK)
![GET Historial de logs](images/04_Logs/get-logs-historial.jfif)

#### Archivo JSON de logs generado automáticamente
![Archivo JSON de logs](images/04_Logs/usuarios-log-archivo.jfif)
=======
![POST Login](images/post-login.jpg)

#### GET - Sin token (401 Unauthorized)
![GET Sin token](images/get-sin-token.jgp)

#### GET - Con token (200 OK)
![GET Con token](images/get-con-token.jpg)

#### POST - Refresh token (200 OK)
![POST Refresh](images/post-refresh.jpg)
>>>>>>> origin/main

---

## 👨‍💻 Autor
Wirkin Alexi Montero Vásquez
