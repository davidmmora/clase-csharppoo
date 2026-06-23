namespace PaquetesYTipos.Ejemplos;

public class TrabajandoConNumeros
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 🔢 Trabajando con Números y GUIDs ---");

        // Random en versiones recientes
        string[] opciones = ["Rojo", "Verde", "Azul", "Amarillo"];
        
        // GetItems: Selecciona elementos aleatorios con reemplazo
        var seleccionados = Random.Shared.GetItems(opciones, 3);
        Console.WriteLine($"Elementos aleatorios (GetItems): {string.Join(", ", seleccionados)}");

        // Shuffle: Aleatoriza el orden de una colección in-place
        int[] numeros = [1, 2, 3, 4, 5];
        Random.Shared.Shuffle(numeros);
        Console.WriteLine($"Arreglo desordenado (Shuffle): {string.Join(", ", numeros)}");

        // Nuevos GUIDs v7 (Ordenables por tiempo)
        Guid nuevoGuidV7 = Guid.CreateVersion7();
        Console.WriteLine($"Nuevo GUID v7: {nuevoGuidV7}");
    }
}