namespace BasculasOOP.Models.Interfaces;

/// <summary>
/// CONCEPTOS: Abstracción a través de Interfaces
/// Una interfaz es un "contrato". Define QUÉ debe hacer una clase (los métodos y propiedades), 
/// pero no CÓMO lo hace (sin implementación).
/// Cualquier clase que implemente esta interfaz está obligada a proveer el código para estos métodos.
/// </summary>
public interface IConectable
{
    // Las interfaces en C# por defecto tienen métodos públicos. No llevan cuerpo { }
    bool ConectarRed(string nombreRed);
    void DesconectarRed();
    void EnviarDatos(string datos);
}
