using System;
using BasculasOOP.Models.Composicion;
using BasculasOOP.Models.Enums;

namespace BasculasOOP.Models.Base;

/// <summary>
/// CONCEPTOS: Clase Abstracta y Abstracción
/// Una clase 'abstract' NO se puede instanciar directamente (no puedes hacer `new Bascula()`).
/// Sirve como una "plantilla base" para que otras clases hereden de ella.
/// </summary>
public abstract class Bascula
{
    // ==========================================
    // CONCEPTO: Encapsulamiento
    // Ocultar el estado interno (campos privados) y exponer solo lo necesario de forma segura (propiedades públicas).
    // ==========================================
    private decimal _capacidadMaxima; // Campo privado, no accesible desde fuera de la clase

    // Propiedad pública que controla cómo se accede o modifica _capacidadMaxima
    public decimal CapacidadMaxima
    {
        get { return _capacidadMaxima; }
        protected set // 'protected' significa que solo esta clase y las clases hijas pueden modificar el valor
        {
            if (value <= 0)
                throw new ArgumentException("La capacidad máxima debe ser mayor a 0.");
            _capacidadMaxima = value;
        }
    }

    // Propiedades auto-implementadas (C# crea el campo privado automáticamente por detrás)
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public bool EstaEncendida { get; private set; } // Cualquiera puede leer si está encendida, solo la clase puede cambiarlo

    // ==========================================
    // CONCEPTO: Constructor base
    // ==========================================
    protected Bascula(string marca, string modelo, decimal capacidadMaxima)
    {
        Marca = marca;
        Modelo = modelo;
        CapacidadMaxima = capacidadMaxima; // Usamos la propiedad para que valide el valor
        EstaEncendida = false;
    }

    // ==========================================
    // CONCEPTO: Métodos regulares
    // Comportamiento que todas las básculas comparten.
    // ==========================================
    public void Encender()
    {
        EstaEncendida = true;
        Console.WriteLine($"[{Marca} {Modelo}] Báscula encendida.");
    }

    public void Apagar()
    {
        EstaEncendida = false;
        Console.WriteLine($"[{Marca} {Modelo}] Báscula apagada.");
    }

    // ==========================================
    // CONCEPTO: Método Virtual (Polimorfismo preparatorio)
    // 'virtual' significa que las clases hijas pueden (si quieren) sobrescribir (override) este método para cambiar su comportamiento.
    // Si no lo sobrescriben, usarán este comportamiento por defecto.
    // ==========================================
    public virtual LecturaPeso PesarObjeto(decimal pesoSimulado)
    {
        if (!EstaEncendida)
            throw new InvalidOperationException("No se puede pesar porque la báscula está apagada.");

        if (pesoSimulado > CapacidadMaxima)
        {
            Console.WriteLine("¡ERROR! Sobrecarga. El peso supera la capacidad máxima.");
            return new LecturaPeso(0, UnidadPeso.Kilogramos); // Retornamos 0 por error
        }

        return new LecturaPeso(pesoSimulado, UnidadPeso.Kilogramos);
    }

    // ==========================================
    // CONCEPTO: Método Abstracto (Abstracción estricta)
    // 'abstract' obliga a TODAS las clases hijas a implementar este método sí o sí.
    // No tiene código aquí (no tiene { ... }).
    // ==========================================
    public abstract void Calibrar();
}
