using DatosYLinq.Data;
using DatosYLinq.Models;
using DatosYLinq.Services;

namespace DatosYLinq.Ejemplos;

public class ManejoDeDatosEFCore
{
    public static async Task Ejecutar()
    {
        Console.WriteLine("\n--- 🗄️ Tema 1: Entity Framework Core (Base de Datos) ---");

        using var context = new AppDbContext();

        // 1. Code First: Creación de la base de datos en tiempo de ejecución
        Console.WriteLine("🔹 Verificando base de datos SQLite...");
        context.Database.EnsureDeleted(); // Para iniciar limpios en cada ejecución
        context.Database.EnsureCreated(); // Crea las tablas y esquema automáticamente
        
        Console.WriteLine("Base de datos creada exitosamente.");

        // Obtenemos los datos de la API (Bajamos la cantidad a 5 para no saturar la DEMO_KEY)
        var nasaDatos = await NasaApiClient.ObtenerImagenes(5);

        if (nasaDatos.Count == 0) return;

        // 2. Operaciones de Inserción (y Transacciones)
        Console.WriteLine("\n🔹 Insertando datos usando una Transacción...");
        using var transaccion = context.Database.BeginTransaction();
        try
        {
            foreach (var dato in nasaDatos)
            {
                var nuevaEntidad = new ApodEntity
                {
                    Title = dato.Title,
                    Explanation = dato.Explanation,
                    Url = dato.Url,
                    Date = dato.Date,
                    MediaType = dato.MediaType
                };
                
                context.Apods.Add(nuevaEntidad);
            }

            // Guardar cambios en la base de datos
            context.SaveChanges();
            
            // Si todo salió bien, completamos la transacción
            transaccion.Commit();
            Console.WriteLine($"{nasaDatos.Count} registros guardados en SQLite.");
        }
        catch (Exception ex)
        {
            transaccion.Rollback();
            Console.WriteLine($"Error al guardar en BD: {ex.Message}");
        }

        // 3. Consulta de Datos (Querying) a través del Modelo
        Console.WriteLine("\n🔹 Consultando los primeros 3 registros desde la BD...");
        var primerosRegistros = context.Apods.Take(3).ToList();
        
        foreach (var registro in primerosRegistros)
        {
            Console.WriteLine($"- [{registro.Date}] {registro.Title} ({registro.MediaType})");
        }
    }
}