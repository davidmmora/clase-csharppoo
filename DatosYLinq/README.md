# Proyecto: Datos y LINQ en .NET

Este proyecto es una guía práctica enfocada en tres pilares fundamentales en el desarrollo moderno con C#:
1. Consumo de **APIs Externas** (usando la API pública de la NASA).
2. **Entity Framework Core (EF Core)** para acceso a datos (usando SQLite).
3. **LINQ (Language Integrated Query)**, destacando características clásicas y las **últimas novedades introducidas en .NET 9**.

A continuación, se detalla paso a paso cómo se ha implementado este proyecto para que puedas comprenderlo e implementarlo desde cero.

---

## � Guía Paso a Paso: Cómo Desarrollar este Proyecto desde Cero

Para replicar este proyecto en vivo con tu grupo, sigan este orden de desarrollo. Así irán construyendo desde los cimientos (modelos), pasando por el servicio (API), la base de datos (EF Core) y terminando con las consultas en LINQ.

### Paso 1: Creación del Proyecto e Instalación de Paquetes
1. Crear el proyecto de consola:
   ```bash
   dotnet new console -n DatosYLinq
   cd DatosYLinq
   ```
2. Instalar el proveedor de SQLite para Entity Framework Core. Este paquete trae consigo todo lo necesario de EF Core.
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   ```

### Paso 2: Creación de la Estructura de Carpetas
Dentro del directorio del proyecto (`DatosYLinq`), crea las siguientes carpetas para organizar el código:
- `Models/` (Para las clases que representan la estructura de los datos)
- `Services/` (Para la lógica de conexión y consumo de la API de la NASA)
- `Data/` (Para la configuración de Entity Framework y la Base de Datos)
- `Ejemplos/` (Para las clases que ejecutan la lógica principal del tema 1 y tema 2)

### Paso 3: Definir los Modelos (`Models/`)
La base de todo son los datos. Empezaremos definiendo cómo lucen.
1. Crea `Models/ApodResponse.cs`. Esta clase mapea el JSON que nos entregará la API de la NASA.
2. Crea `Models/ApodEntity.cs`. Esta clase es muy parecida, pero la utilizaremos específicamente como *Entidad* para decirle a EF Core cómo debe crear la tabla en la base de datos (incluyendo su clave primaria `Id`).

### Paso 4: Consumir la API Externa (`Services/`)
1. Crea `Services/NasaApiClient.cs`.
2. Dentro, instanciaremos un `HttpClient` (como `static readonly`) y crearemos el método asíncrono para hacer un `GetFromJsonAsync` apuntando a `api.nasa.gov`.
3. *(Opcional pero recomendado en clase)*: Agrega un bloque `try/catch` que devuelva datos de respaldo *hardcodeados* en caso de que el internet falle o superen las cuotas de la API.

### Paso 5: Configurar la Base de Datos (`Data/`)
1. Crea la clase `Data/AppDbContext.cs`.
2. Haz que herede de `DbContext` (necesitarás el `using Microsoft.EntityFrameworkCore;`).
3. Agrega la propiedad `DbSet<ApodEntity> Apods { get; set; }` para representar la tabla.
4. Sobrescribe el método `OnConfiguring` para indicarle a EF Core que use SQLite: `optionsBuilder.UseSqlite("Data Source=nasa_data.db");`.

### Paso 6: Lógica de EF Core (`Ejemplos/ManejoDeDatosEFCore.cs`)
1. Crea la clase `Ejemplos/ManejoDeDatosEFCore.cs`.
2. Aquí crearemos el método principal asíncrono.
3. Lo primero es asegurar la creación de la BD usando `context.Database.EnsureCreated()`.
4. Obtenemos los datos llamando al `NasaApiClient`.
5. Iteramos los datos obtenidos y usamos una transacción (`BeginTransaction()`) para insertarlos en `context.Apods.Add(...)`, guardando finalmente con `SaveChanges()` y `Commit()`.

### Paso 7: Manipulación con LINQ (`Ejemplos/ManejoDeLinq.cs`)
1. Crea la clase `Ejemplos/ManejoDeLinq.cs`.
2. Instanciaremos de nuevo el contexto y traeremos los datos de la base de datos a una lista en memoria (`ToList()`).
3. Comenzaremos mostrando sintaxis **LINQ clásica** (`Where`, `OrderByDescending`, `Select`).
4. Avanzaremos a mostrar el método `DistinctBy` (introducido en .NET 6).
5. Terminaremos demostrando las nuevas funciones estrella de **.NET 9**: `CountBy`, `AggregateBy` e `Index()`.

### Paso 8: Punto de Entrada (`Program.cs`)
1. Finalmente, limpiamos el `Program.cs`.
2. Mandamos llamar los dos archivos de ejecución. Como el paso de EF Core incluye llamadas a la API y BD, usaremos `await`:
   ```csharp
   await ManejoDeDatosEFCore.Ejecutar();
   ManejoDeLinq.Ejecutar();
   ```

---

## �📡 1. Consumo de APIs Externas (`Services/NasaApiClient.cs`)

En las aplicaciones modernas, a menudo necesitamos consumir información de otros servicios. En este proyecto consumimos la API *Astronomy Picture of the Day (APOD)* de la NASA.

### ¿Cómo lo implementamos?
Utilizamos la clase `HttpClient` proporcionada por .NET. Para mayor eficiencia de memoria, declaramos la instancia de `HttpClient` como `static readonly`, evitando el agotamiento de sockets.

Para obtener y transformar el JSON de la API directamente a nuestras clases en C#, utilizamos el método de extensión `GetFromJsonAsync<T>()`. Este método descarga la respuesta HTTP y automáticamente deserializa el JSON a nuestra lista de objetos `ApodResponse`.

```csharp
var respuesta = await _httpClient.GetFromJsonAsync<List<ApodResponse>>(url);
```

> **Nota:** El servicio incluye un método de respaldo (Fallback) en caso de que falle la conexión o se exceda el límite de cuota de la API pública.

---

## 🗄️ 2. Entity Framework Core y SQLite (`Data/` y `ManejoDeDatosEFCore.cs`)

**Entity Framework Core (EF Core)** es un ORM (Object-Relational Mapper) que nos permite trabajar con bases de datos utilizando objetos C# en lugar de escribir sentencias SQL manuales. En este caso, usamos el proveedor de **SQLite** para simplificar el entorno local.

### a) Configurando el Contexto de Datos (`AppDbContext.cs`)
El `AppDbContext` hereda de `DbContext`. Representa una sesión con la base de datos y permite consultar y guardar instancias de nuestras entidades.
- **`DbSet<ApodEntity>`**: Actúa como la representación de la tabla en C#.
- **`OnConfiguring`**: Método sobrescrito donde indicamos que usaremos SQLite y le damos el nombre del archivo de base de datos local (`Data Source=nasa_data.db`).

### b) Code First y Operaciones CRUD (`ManejoDeDatosEFCore.cs`)
- **Code First**: Al inicio de la ejecución, usamos `context.Database.EnsureCreated();` para que EF Core analice nuestras clases (Modelos) y cree automáticamente el esquema (Tablas) en SQLite sin necesidad de crear scripts manuales.
- **Transacciones**: Demostramos cómo guardar registros múltiples de manera segura usando `BeginTransaction()`. Si todas las operaciones de inserción (`Add`) y guardado (`SaveChanges`) tienen éxito, llamamos a `Commit()`. Si ocurre un error a la mitad, ejecutamos `Rollback()` asegurando la integridad de los datos.

---

## 🔍 3. Consultas y Manipulación de Datos con LINQ (`ManejoDeLinq.cs`)

**LINQ** permite escribir consultas sobre colecciones de datos directamente en C# de manera declarativa. En este proyecto traemos los registros desde la base de datos y analizamos diferentes formas de agruparlos y consultarlos, haciendo énfasis en las **nuevas herramientas de .NET 9**.

### a) LINQ Clásico y .NET 6
- **`Where()` y `OrderByDescending()`**: Filtramos la lista y la ordenamos cronológicamente.
- **`Select()` (Proyecciones)**: Lo usamos para crear *tipos anónimos* (objetos al vuelo) seleccionando solo el `Title` y el `Date`, ignorando otras propiedades que consumen memoria innecesariamente.
- **`DistinctBy()` (.NET 6)**: Obtenemos una lista de elementos únicos basándonos en una propiedad específica (ej. los tipos de media: `image` o `video`).

### b) Novedades en LINQ con .NET 9 🚀
El proyecto demuestra cómo .NET 9 simplifica operaciones que antes requerían complejas combinaciones de `GroupBy` y `Select`:

1. **`CountBy`**: 
   Agrupa elementos según una clave y te devuelve el conteo de cada grupo directamente. Antes necesitabas hacer `.GroupBy(x => x.Prop).Select(g => new { g.Key, Count = g.Count() })`.
   ```csharp
   var conteosPorTipo = registros.CountBy(r => r.MediaType);
   ```

2. **`AggregateBy`**:
   Agrupa los elementos por una clave y acumula un valor (como sumar, o en nuestro caso, concatenar strings). En el ejemplo lo usamos para agrupar las imágenes por su tipo y concatenar todos sus títulos.
   ```csharp
   var nombresConcatenadosPorTipo = registros.AggregateBy(
       keySelector: r => r.MediaType, // Llave de agrupación
       seed: string.Empty,            // Valor inicial del acumulador
       func: (acumulado, registro) => ... // Lógica de concatenación
   );
   ```

3. **`Index()`**:
   Devuelve una colección de tuplas `(Index, Item)`. Esto nos ahorra tener que declarar un contador `int i = 0;` afuera de un ciclo `foreach` cuando necesitamos el índice de la iteración.
   ```csharp
   var top3 = registros.Take(3).Index();
   foreach (var (indice, item) in top3) {
       Console.WriteLine($"Registro #{indice + 1}: {item.Title}");
   }
   ```

---

## 🚀 Cómo ejecutar este proyecto

1. Abre tu terminal.
2. Navega hasta el directorio del proyecto: `cd DatosYLinq`
3. Restaura y ejecuta:
   ```bash
   dotnet run
   ```
4. Observarás cómo se crea automáticamente un archivo `nasa_data.db` (la base de datos SQLite) en tu directorio, cómo se descargan los datos y la ejecución de todas las funciones LINQ en consola.
