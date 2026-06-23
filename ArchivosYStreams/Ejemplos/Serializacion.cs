using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Xml.Serialization;

namespace ArchivosYStreams.Ejemplos;

// Grafo de Objetos a serializar
public class Direccion
{
    public string Calle { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
}

public class Persona
{
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
    
    // Un objeto que referencia a otros objetos (Grafo)
    public List<Direccion> Direcciones { get; set; } = new();
}

public class Serializacion
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 📦 Tema 4: Serialización y Deserialización de Objetos ---");

        Persona sujetoPrueba = new Persona
        {
            Nombre = "Juan Perez",
            Edad = 35,
            Direcciones = new List<Direccion>
            {
                new Direccion { Calle = "Av. Reforma 123", Ciudad = "CDMX" },
                new Direccion { Calle = "Calle 50", Ciudad = "Monterrey" }
            }
        };

        // 1. Serialización XML
        Console.WriteLine("🔹 Serialización XML (XmlSerializer):");
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Persona));
        
        using (StringWriter xmlWriter = new StringWriter())
        {
            xmlSerializer.Serialize(xmlWriter, sujetoPrueba);
            Console.WriteLine(xmlWriter.ToString());
        }

        // 2. Serialización JSON
        Console.WriteLine("\n🔹 Serialización JSON (System.Text.Json):");
        JsonSerializerOptions opcionesJson = new JsonSerializerOptions 
        { 
            WriteIndented = true // Formato bonito con sangrías
        };
        
        string json = JsonSerializer.Serialize(sujetoPrueba, opcionesJson);
        Console.WriteLine(json);

        // 3. Generación de Esquema JSON (Novedad .NET 9+)
        Console.WriteLine("\n🔹 Generador de Esquemas JSON (JsonSchemaExporter):");
        JsonNode esquema = opcionesJson.GetJsonSchemaAsNode(typeof(Persona));
        Console.WriteLine(esquema.ToString());
    }
}