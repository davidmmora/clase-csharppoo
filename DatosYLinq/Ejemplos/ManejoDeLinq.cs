using DatosYLinq.Data;
using DatosYLinq.Models;

namespace DatosYLinq.Ejemplos;

public class ManejoDeLinq
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 🔍 Tema 2: Consultas y Manipulación de Datos con LINQ ---");

        using var context = new AppDbContext();
        
        // Traemos todos los registros a memoria para jugar con LINQ
        List<ApodEntity> registros = context.Apods.ToList();

        if (registros.Count == 0)
        {
            Console.WriteLine("No hay registros para mostrar LINQ.");
            return;
        }

        // 1. Filtrar, ordenar y proyectar (Select)
        Console.WriteLine("\n🔹 Filtrado Clásico, Order y Proyección (Select):");
        var imagenes = registros
            .Where(r => r.MediaType == "image")
            .OrderByDescending(r => r.Date) // Filtramos usando OrderByDescending clásico
            .Select(r => new { r.Title, r.Date }) // Tipo Anónimo (Proyección)
            .Take(3);
            
        foreach (var img in imagenes)
        {
            Console.WriteLine($"- {img.Title} ({img.Date})");
        }

        // 2. LINQ en versiones anteriores (TryGetNonEnumeratedCount y DistinctBy)
        Console.WriteLine("\n🔹 DistinctBy (.NET 6): Tipos de Medios únicos");
        var tiposMedios = registros.DistinctBy(r => r.MediaType).Select(r => r.MediaType);
        Console.WriteLine($"Tipos encontrados: {string.Join(", ", tiposMedios)}");

        // 3. NOVEDADES LINQ .NET 9 (CountBy, AggregateBy, Index)
        Console.WriteLine("\n🔹 Novedad .NET 9: CountBy (Agrupación directa)");
        // CountBy agrupa los elementos por una llave (MediaType) y devuelve el conteo directamente
        var conteosPorTipo = registros.CountBy(r => r.MediaType);
        foreach (var grupo in conteosPorTipo)
        {
            Console.WriteLine($"Tipo: {grupo.Key} -> Total: {grupo.Value}");
        }

        Console.WriteLine("\n🔹 Novedad .NET 9: AggregateBy");
        // AggregateBy nos permite agrupar y acumular un cálculo, por ejemplo concatenar los títulos por tipo de media.
        var nombresConcatenadosPorTipo = registros.AggregateBy(
            keySelector: r => r.MediaType,
            seed: string.Empty,
            func: (acumulado, registro) => string.IsNullOrEmpty(acumulado) ? registro.Title : $"{acumulado} | {registro.Title}"
        );
        foreach (var agg in nombresConcatenadosPorTipo)
        {
            Console.WriteLine($"[{agg.Key}]: {agg.Value.Substring(0, Math.Min(agg.Value.Length, 50))}...");
        }

        Console.WriteLine("\n🔹 Novedad .NET 9: Index()");
        // Index devuelve una tupla (Index, Item) para iterar sin un contador externo
        var top3 = registros.Take(3).Index();
        foreach (var (indice, item) in top3)
        {
            Console.WriteLine($"Registro #{indice + 1}: {item.Title}");
        }
    }
}