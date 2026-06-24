using System.Net.Http.Json;
using DatosYLinq.Models;

namespace DatosYLinq.Services;

public class NasaApiClient
{
    private static readonly HttpClient _httpClient = new();

    public static async Task<List<ApodResponse>> ObtenerImagenes(int cantidad = 15)
    {
        Console.WriteLine($"\n📡 Descargando {cantidad} registros de la API de la NASA...");
        
        // Usamos la API de Astronomy Picture of the Day (APOD) de forma aleatoria
        string url = $"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&count={cantidad}";
        
        try
        {
            var respuesta = await _httpClient.GetFromJsonAsync<List<ApodResponse>>(url);
            return respuesta ?? GenerarDatosDeRespaldo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar con la API de la NASA: {ex.Message}");
            Console.WriteLine("⚠️ Usando datos de respaldo locales para no interrumpir la clase...\n");
            return GenerarDatosDeRespaldo();
        }
    }

    private static List<ApodResponse> GenerarDatosDeRespaldo()
    {
        return new List<ApodResponse>
        {
            new ApodResponse { Title = "Galaxia de Andrómeda", Explanation = "Galaxia espiral vecina.", Date = "2024-01-01", MediaType = "image", Url = "https://example.com/1.jpg" },
            new ApodResponse { Title = "Nebulosa de Orión", Explanation = "Región de formación estelar.", Date = "2024-01-02", MediaType = "image", Url = "https://example.com/2.jpg" },
            new ApodResponse { Title = "Superficie de Marte", Explanation = "Foto tomada por el Rover.", Date = "2024-01-03", MediaType = "image", Url = "https://example.com/3.jpg" },
            new ApodResponse { Title = "Agujero Negro Supermasivo", Explanation = "Simulación por computadora.", Date = "2024-01-04", MediaType = "video", Url = "https://example.com/4.mp4" },
            new ApodResponse { Title = "Júpiter y Europa", Explanation = "Observación desde telescopio.", Date = "2024-01-05", MediaType = "image", Url = "https://example.com/5.jpg" }
        };
    }
}