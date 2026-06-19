using System;
using BasculasOOP.Models.Enums;

namespace BasculasOOP.Models.Composicion;

/// <summary>
/// CONCEPTOS: Clases Regulares y Composición
/// Esta es una clase sencilla que representa los datos de un peso en un momento dado.
/// La Composición se refiere a cuando una clase "tiene un" objeto de otra clase (Ej. La báscula genera o tiene lecturas).
/// </summary>
public class LecturaPeso
{
    // Propiedades auto-implementadas
    public decimal Valor { get; set; }
    public UnidadPeso Unidad { get; set; }
    public DateTime FechaHora { get; set; }

    /// <summary>
    /// CONCEPTO: Constructor
    /// Es un método especial que se llama automáticamente cuando se crea un objeto de esta clase (instanciación usando 'new').
    /// Sirve para inicializar el objeto en un estado válido.
    /// </summary>
    public LecturaPeso(decimal valor, UnidadPeso unidad)
    {
        Valor = valor;
        Unidad = unidad;
        FechaHora = DateTime.Now;
    }

    /// <summary>
    /// Método para mostrar la lectura formateada.
    /// </summary>
    public override string ToString()
    {
        return $"{Valor:F2} {Unidad} (Registrado a las {FechaHora:HH:mm:ss})";
    }
}
