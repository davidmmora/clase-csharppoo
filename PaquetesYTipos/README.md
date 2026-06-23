# Proyecto: Paquetes y Tipos en .NET

Este proyecto es una guía práctica que demuestra características modernas de C# y .NET (especialmente C# 11 y C# 12). Abarca desde la manipulación de tipos de datos comunes y colecciones, hasta técnicas avanzadas para el uso eficiente de la memoria y el empaquetado de la aplicación.

## 📁 Contenido de Ejemplos (`/Ejemplos`)

### 1. Trabajando con Números y GUIDs (`TrabajandoConNumeros.cs`)
- **`Random.Shared`**: Uso de la instancia global y *thread-safe* para la generación de números y selecciones aleatorias sin tener que instanciar la clase `Random`.
  - **`GetItems()`**: Selecciona un número determinado de elementos aleatorios de una colección.
  - **`Shuffle()`**: Mezcla de forma aleatoria los elementos de un arreglo o lista *in-place* (sin gastar memoria extra).
- **GUID v7 (`Guid.CreateVersion7`)**: Generación de UUIDs que incluyen una marca de tiempo integrada, lo que los hace ordenables de manera cronológica en bases de datos.

### 2. Trabajando con Texto y Regex (`TrabajandoConTexto.cs`)
- **Manipulación de Strings**: Ejemplos clásicos con `IndexOf`, `Substring` y `Split`.
- **Source Generators (`[GeneratedRegex]`)**: Uso de compilación de expresiones regulares en tiempo de compilación. Esto mejora significativamente el rendimiento en comparación con instanciar `new Regex()`.
- **`[StringSyntaxAttribute]`**: Un atributo que le indica a Visual Studio o VS Code cómo colorear e inspeccionar el contenido de un string (por ejemplo, notificando al IDE que un string debe ser coloreado como `Regex`).

### 3. Colecciones Avanzadas (`Colecciones.cs`)
- **Colecciones genéricas**: Demostraciones prácticas de `List`, `Dictionary`, `Queue` (FIFO), `Stack` (LIFO) y `PriorityQueue` (colas basadas en prioridad).
- **Thread-Safety e Inmutabilidad**:
  - `ImmutableList`: Protege los datos impidiendo modificaciones después de la creación.
  - `ConcurrentDictionary`: Colección segura para manipular de forma concurrente con múltiples hilos.
- **Collection Expressions y Operador Spread (`..`)**: Sintaxis moderna de C# 12 `[]` para instanciar colecciones de manera limpia, además de utilizar `..` para "desempaquetar" y combinar colecciones fácilmente en una sola línea.

### 4. Memoria Eficiente (`MemoriaEficiente.cs`)
- **Índices (`^`)**: Simplifican el acceso desde el final de las colecciones. Ejemplo: `[^1]` obtiene el último elemento.
- **Rangos (`..`)**: Permiten extraer sub-colecciones fácilmente con la sintaxis `[inicio..fin_exclusivo]`.
- **`ReadOnlySpan<T>` y `Span<T>`**: Una de las características más importantes de alto rendimiento en C#. Permiten apuntar a fragmentos de memoria (o extraer sub-cadenas de texto) directamente **sin crear copias adicionales** en el heap, reduciendo la presión en el recolector de basura (Garbage Collector).

## 📦 Empaquetado y Configuración (`Program.cs` y `.csproj`)

El proyecto demuestra ciertas prácticas modernas de compilación en .NET:
1. **AOT (Ahead-of-Time) Compilation (`<PublishAot>true</PublishAot>`)**: Precompila la aplicación a código nativo de la plataforma. Esto genera un ejecutable autocontenido mucho más rápido en tiempo de inicio y con un uso de memoria drásticamente reducido.
2. **Características Preview (`<EnablePreviewFeatures>true</EnablePreviewFeatures>`)**: Bandera activada en el `.csproj` para experimentar con código y librerías que llegarán en versiones futuras del lenguaje.
