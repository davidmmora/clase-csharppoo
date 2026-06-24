namespace DatosYLinq.Models;

public class ApodEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
}