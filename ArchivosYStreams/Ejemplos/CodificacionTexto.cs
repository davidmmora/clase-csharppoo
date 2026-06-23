using System.Text;

namespace ArchivosYStreams.Ejemplos;

public class CodificacionTexto
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 🔤 Tema 3: Codificación y Decodificación de Texto ---");
        
        // .NET internamente usa UTF-16 para string y char
        string texto = "Códificación y Emojis 🚀";
        
        // Convertir de texto a arreglos de bytes según la codificación (Codificación)
        byte[] bytesAscii = Encoding.ASCII.GetBytes(texto);
        byte[] bytesUtf8 = Encoding.UTF8.GetBytes(texto);
        byte[] bytesUtf16 = Encoding.Unicode.GetBytes(texto); // Unicode en .NET significa UTF-16
        
        Console.WriteLine($"Texto original: {texto}");
        Console.WriteLine($"Tamaño en ASCII: {bytesAscii.Length} bytes");
        Console.WriteLine($"Tamaño en UTF-8: {bytesUtf8.Length} bytes");
        Console.WriteLine($"Tamaño en UTF-16: {bytesUtf16.Length} bytes");

        // Convertir de arreglos de bytes a texto (Decodificación)
        // Ojo: ASCII perderá acentos y emojis por no soportarlos
        string decodificadoAscii = Encoding.ASCII.GetString(bytesAscii);
        string decodificadoUtf8 = Encoding.UTF8.GetString(bytesUtf8);

        Console.WriteLine($"\nDecodificado desde ASCII: {decodificadoAscii} (Pérdida de datos)");
        Console.WriteLine($"Decodificado desde UTF-8: {decodificadoUtf8} (Perfecto)");
    }
}