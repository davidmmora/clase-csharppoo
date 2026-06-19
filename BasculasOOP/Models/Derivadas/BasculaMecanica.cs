using System;
using BasculasOOP.Models.Base;
using BasculasOOP.Models.Composicion;

namespace BasculasOOP.Models.Derivadas;

/// <summary>
/// CONCEPTOS: Herencia y Polimorfismo
/// Otra clase que hereda de la misma base (`Bascula`), pero se comporta diferente a la digital.
/// </summary>
public class BasculaMecanica : Bascula
{
    public decimal ToleranciaResorte { get; set; }

    public BasculaMecanica(string marca, string modelo, decimal capacidadMaxima, decimal tolerancia) 
        : base(marca, modelo, capacidadMaxima)
    {
        ToleranciaResorte = tolerancia;
    }

    // ==========================================
    // Polimorfismo: Obligatorio
    // Implementación obligatoria, pero el proceso de una báscula mecánica es distinto (ajuste de tuerca)
    // ==========================================
    public override void Calibrar()
    {
        Console.WriteLine($"[{Marca} {Modelo}] Gire la perilla inferior hasta que la aguja marque exactamente cero.");
        Console.WriteLine("Ajuste de resorte completado.");
    }

    // ==========================================
    // CONCEPTO: Polimorfismo (Sobrescritura de Virtual)
    // OPCIONAL: Sobrescribimos el método virtual de la clase padre para agregar un margen de error (por ser mecánica).
    // ==========================================
    public override LecturaPeso PesarObjeto(decimal pesoSimulado)
    {
        // En una báscula mecánica, simulamos que el resorte añade un pequeño error
        decimal pesoConTolerancia = pesoSimulado + ToleranciaResorte;
        
        // Llamamos al método de la clase padre usando `base.PesarObjeto` pero con el nuevo valor calculado
        return base.PesarObjeto(pesoConTolerancia);
    }
}
