namespace PaquetesYTipos.Ejemplos;

public class MemoriaEficiente
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- ⚡ Gestión Eficiente de Memoria (Índices, Rangos y Spans) ---");

        string[] nombres = ["Ana", "Beto", "Carlos", "Diana", "Elena"];

        // Índices (Index): El operador ^ cuenta desde el final hacia atrás (1-based from the end)
        string ultimo = nombres[^1]; // "Elena"
        string penultimo = nombres[^2]; // "Diana"
        Console.WriteLine($"Índices - Último: {ultimo}, Penúltimo: {penultimo}");

        // Rangos (Range): El operador .. define [inicio..fin_exclusivo]
        string[] subArreglo = nombres[1..4]; // Del índice 1 (Beto) al 3 (Diana)
        Console.WriteLine($"Rangos [1..4]: {string.Join(", ", subArreglo)}");

        // Spans (Ventanas directas a la memoria sin asignar nuevas copias)
        string textoLargo = "EsteEsUnTextoLargoParaProbarSpan";
        
        // Asignación directa con Spans y rangos. Muy usado en alto rendimiento.
        ReadOnlySpan<char> porcionRango = textoLargo.AsSpan()[8..13]; // "Texto"
        
        Console.WriteLine($"Extracción con Span (sin asignar memoria extra): '{porcionRango.ToString()}'");
    }
}