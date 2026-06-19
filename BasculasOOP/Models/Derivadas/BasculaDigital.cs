using System;
using BasculasOOP.Models.Base;
using BasculasOOP.Models.Interfaces;

namespace BasculasOOP.Models.Derivadas;

/// <summary>
/// CONCEPTOS: Herencia, Polimorfismo e Interfaces
/// `BasculaDigital` HEREDA (:) de `Bascula`. Adquiere todas sus propiedades (Marca, Modelo, etc.) y métodos (Encender, Apagar).
/// Además, IMPLEMENTA (,) la interfaz `IConectable`, prometiendo incluir el código para red.
/// </summary>
public class BasculaDigital : Bascula, IConectable
{
    // Campo propio de la clase hija
    public int NivelBateriaPorcentaje { get; private set; }

    /// <summary>
    /// CONCEPTO: Constructor de clase derivada
    /// Usa `base(...)` para pasarle a la clase padre (`Bascula`) los datos que necesita su propio constructor.
    /// </summary>
    public BasculaDigital(string marca, string modelo, decimal capacidadMaxima, int nivelBateria) 
        : base(marca, modelo, capacidadMaxima)
    {
        NivelBateriaPorcentaje = nivelBateria;
    }

    // ==========================================
    // CONCEPTO: Polimorfismo (Sobrescritura de Abstract)
    // OBLIGATORIO: Como heredamos de Bascula, debemos dar cuerpo a Calibrar()
    // ==========================================
    public override void Calibrar()
    {
        Console.WriteLine($"[{Marca} {Modelo}] Iniciando calibración electrónica con ceros digitales...");
        // Simulamos la lógica
        Console.WriteLine("Calibración digital completada. Tara establecida en 0.00");
    }

    // ==========================================
    // Implementación del CONTRATO (Interfaz IConectable)
    // ==========================================
    public bool ConectarRed(string nombreRed)
    {
        Console.WriteLine($"[{Marca}] Conectando al Wi-Fi: {nombreRed}...");
        return true; // Simulación de éxito
    }

    public void DesconectarRed()
    {
        Console.WriteLine($"[{Marca}] Desconectado del Wi-Fi.");
    }

    public void EnviarDatos(string datos)
    {
        Console.WriteLine($"[{Marca}] Transmitiendo datos a la nube: {datos}");
    }
}
