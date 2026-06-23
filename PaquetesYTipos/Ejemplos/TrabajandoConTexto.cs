using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace PaquetesYTipos.Ejemplos;

public partial class TrabajandoConTexto
{
    // Uso de [GeneratedRegex] para compilar la expresión por adelantado y optimizar rendimiento
    [GeneratedRegex(@"^\d+$")]
    private static partial Regex SoloDigitosRegex();

    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 📝 Trabajando con Texto y Regex ---");

        string texto = "Hola 12345 Mundo";
        
        // Extracción clásica
        int indice = texto.IndexOf("12345");
        string extraido = texto.Substring(indice, 5);
        Console.WriteLine($"Texto extraído (Substring): {extraido}");

        // División básica
        string[] partes = texto.Split(' ');
        Console.WriteLine($"Partes separadas por espacio: {string.Join(" - ", partes)}");

        // Validación con Regex optimizada
        string entradaUsuario = "98765";
        bool esValido = SoloDigitosRegex().IsMatch(entradaUsuario);
        Console.WriteLine($"¿La entrada '{entradaUsuario}' contiene solo dígitos? {esValido}");

        // Ayudas visuales en Visual Studio / VS Code
        MostrarEjemploSintaxis(@"\b[A-Z]+\b");
    }

    // [StringSyntax] ayuda al IDE a colorear e interpretar el string inyectado como Regex
    private static void MostrarEjemploSintaxis([StringSyntax(StringSyntaxAttribute.Regex)] string patron)
    {
        Console.WriteLine($"Patrón Regex (Resaltado en tu IDE): {patron}");
    }
}