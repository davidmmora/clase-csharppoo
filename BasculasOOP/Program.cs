using System;
using System.Collections.Generic;
using BasculasOOP.Models.Base;
using BasculasOOP.Models.Derivadas;
using BasculasOOP.Models.Interfaces;

namespace BasculasOOP;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine(" SISTEMA DE BÁSCULAS OOP - DEMOSTRACIÓN COMPLETA");
        Console.WriteLine("=================================================");

        // 1. CLASES Y OBJETOS (Instanciación)
        // Creamos objetos específicos a partir de nuestros "moldes" (Clases)
        BasculaDigital basculaTorrey = new BasculaDigital("Torrey", "L-EQ 10/20", 20.0m, 100);
        BasculaMecanica basculaVintage = new BasculaMecanica("Acme", "Retro 1980", 150.0m, 0.5m);

        // 2. ENCAPSULAMIENTO
        // Intentar modificar directamente campos protegidos causaría un error de compilación.
        // basculaTorrey._capacidadMaxima = 50; // ERROR: Privado
        // basculaTorrey.CapacidadMaxima = 50; // ERROR: Es 'protected set', no se puede alterar desde aquí.
        // La única forma de leerlo es de forma pública:
        Console.WriteLine($"Capacidad Torrey: {basculaTorrey.CapacidadMaxima} kg");

        Console.WriteLine("\n--- 3. MÉTODOS HEREDADOS E INTERACCIÓN ---");
        basculaTorrey.Encender();
        basculaVintage.Encender();

        Console.WriteLine("\n--- 4. POLIMORFISMO (Comportamientos diferentes misma orden) ---");
        // POLIMORFISMO CON ABSTRACTO: Ambas son "Basculas", pero cada una se calibra de forma diferente
        basculaTorrey.Calibrar();
        basculaVintage.Calibrar();

        Console.WriteLine("\n--- 5. POLIMORFISMO CON LISTAS (Tratar todo como la clase Base) ---");
        // Podemos meter ambas básculas (Mecánica y Digital) en una lista de la CLASE BASE `Bascula`.
        List<Bascula> inventarioBasculas = new List<Bascula>
        {
            basculaTorrey,
            basculaVintage
        };

        foreach (Bascula bascula in inventarioBasculas)
        {
            // Polimorfismo en acción:
            // Para la Digital, ejecutará el código normal de "PesarObjeto".
            // Para la Mecánica, ejecutará nuestro 'override' que añade el margen de error del resorte.
            var lectura = bascula.PesarObjeto(10.0m);
            Console.WriteLine($"Pesando 10kg en {bascula.Marca}: El resultado es {lectura}");
        }

        Console.WriteLine("\n--- 6. INTERFACES (Uso de capacidades adicionales) ---");
        // Queremos saber si una báscula se puede conectar a internet.
        // Solo la digital implementó la interfaz IConectable.
        foreach (Bascula bascula in inventarioBasculas)
        {
            // Usamos el operador 'is' para verificar si el objeto implementa la interfaz
            if (bascula is IConectable basculaSmart)
            {
                basculaSmart.ConectarRed("Wifi_Almacen");
                basculaSmart.EnviarDatos("Peso registrado: 10kg - Usuario: Admin");
                basculaSmart.DesconectarRed();
            }
            else
            {
                Console.WriteLine($"[{bascula.Marca}] Esta báscula no cuenta con tecnología de red.");
            }
        }

        Console.WriteLine("\n--- FIN DE LA DEMOSTRACIÓN ---");
        basculaTorrey.Apagar();
        basculaVintage.Apagar();
    }
}
