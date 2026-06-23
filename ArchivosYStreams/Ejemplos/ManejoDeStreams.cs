using System.IO.Compression;
using Microsoft.Win32.SafeHandles;

namespace ArchivosYStreams.Ejemplos;

public class ManejoDeStreams
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 🌊 Tema 2: Lectura y Escritura con Streams ---");
        
        string archivoTexto = "datos.txt";
        string archivoComprimido = "datos.brotli";

        // Escritura de texto (StreamWriter con instrucción 'using' tradicional)
        using (StreamWriter writer = File.CreateText(archivoTexto))
        {
            writer.WriteLine("Este es un texto manejado por streams.");
            writer.WriteLine("Se asegura la liberación de recursos.");
        } 
        // Aquí se llama implícitamente a writer.Dispose()

        // Lectura de texto (usando sintaxis 'using' moderna sin llaves)
        using StreamReader reader = File.OpenText(archivoTexto);
        Console.WriteLine("Contenido leído con StreamReader:");
        Console.WriteLine(reader.ReadToEnd());

        // Compresión de Streams (Storage Stream + Function Stream)
        // FileStream almacena los bytes en disco, BrotliStream los comprime al vuelo
        using FileStream fs = File.Create(archivoComprimido);
        using BrotliStream bs = new BrotliStream(fs, CompressionLevel.Optimal);
        using StreamWriter sw = new StreamWriter(bs);
        
        sw.WriteLine("Este texto será empaquetado y comprimido en formato Brotli.");
        sw.WriteLine("Ideal para guardar espacio en grandes volúmenes de datos.");
        // Cerramos explícitamente el StreamWriter superior para vaciar el buffer
        sw.Close(); 
        
        Console.WriteLine($"Archivo comprimido creado: {archivoComprimido} ({new FileInfo(archivoComprimido).Length} bytes)");

        // Acceso aleatorio a archivos (RandomAccess + SafeFileHandle) - Novedad .NET 6+
        using SafeFileHandle handle = File.OpenHandle(archivoTexto, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[100];
        
        // Lee directamente los bytes sin instanciar ningún tipo de Stream
        int bytesLeidos = RandomAccess.Read(handle, buffer, fileOffset: 0);
        Console.WriteLine($"Bytes leídos directamente con RandomAccess: {bytesLeidos}");

        // Limpieza de archivos demo
        File.Delete(archivoTexto);
        File.Delete(archivoComprimido);
    }
}