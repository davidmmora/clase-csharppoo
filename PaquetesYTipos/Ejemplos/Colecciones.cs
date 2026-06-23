using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace PaquetesYTipos.Ejemplos;

public class Colecciones
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 📦 Colecciones y Collection Expressions ---");

        // Colecciones genéricas comunes
        List<string> lista = ["Manzana", "Pera"]; // Sintaxis nueva para instanciar (Collection expression)
        Dictionary<int, string> diccionario = new() { { 1, "Uno" }, { 2, "Dos" } };
        
        Queue<string> cola = new(); // FIFO
        cola.Enqueue("Primero en llegar, primero en salir");
        
        Stack<string> pila = new(); // LIFO
        pila.Push("Último en llegar, primero en salir");
        
        PriorityQueue<string, int> colaPrioridad = new();
        colaPrioridad.Enqueue("Tarea Normal", 2);
        colaPrioridad.Enqueue("Tarea Urgente", 1);

        // Colecciones Inmutables (protección de datos)
        ImmutableList<int> listaInmutable = ImmutableList.Create(1, 2, 3);
        
        // Colecciones concurrentes (seguras para hilos/multithreading)
        ConcurrentDictionary<int, string> diccionarioConcurrente = new();

        // 🌟 Collection Expressions y Operador Spread (..) 
        int[] arreglo1 = [1, 2, 3];
        int[] arreglo2 = [4, 5, 6];
        
        // El Spread Operator saca los elementos de arreglo1 y arreglo2 y los inyecta en la nueva colección
        int[] combinados = [0, .. arreglo1, .. arreglo2, 7];
        
        Console.WriteLine($"Colección combinada (Uso de Spread '..'): {string.Join(", ", combinados)}");
    }
}