# Clase C# Programación Orientada a Objetos (POO)

Este repositorio contiene dos proyectos desarrollados en C# (.NET) diseñados para explicar y demostrar de forma práctica y teórica los pilares de la Programación Orientada a Objetos (POO). El ejemplo central gira en torno al funcionamiento de diferentes tipos de "Básculas".

## Estructura del Repositorio

El repositorio está dividido en dos proyectos principales:

### 1. BasculasOOP (Aplicación de Consola)
Un proyecto de consola puro que implementa el código de las básculas. Aquí encontrarás el código en acción para los siguientes conceptos:
* **Clases y Objetos:** Creación de instancias de básculas.
* **Encapsulamiento:** Protección del estado interno (como la capacidad máxima de la báscula).
* **Herencia:** Clases derivadas (`BasculaDigital`, `BasculaMecanica`) que extienden una clase base (`Bascula`).
* **Polimorfismo:** Métodos sobrescritos (ej. el método `Calibrar()` o `PesarObjeto()`) que actúan diferente según la báscula.
* **Abstracción:** Definición de la clase base `Bascula` que fuerza a sus herederos a implementar ciertos métodos.
* **Interfaces:** Contratos como `IConectable` para básculas que soportan conexión a internet.
* **Composición:** Uso de clases componentes, como `LecturaPeso`.

### 2. ExplicacionOOPWeb (Aplicación Web ASP.NET Core)
Un proyecto web (Razor Pages) diseñado para ser una guía interactiva y visual. 
Cuenta con una página principal (`Index`) donde se explican detalladamente los 8 conceptos clave de OOP:
1. Clases y Objetos
2. Encapsulamiento
3. Herencia
4. Polimorfismo
5. Abstracción
6. Interfaces (Contratos)
7. Composición
8. Inyección de Dependencias (DI)

Cada concepto incluye una definición técnica, un ejemplo de código en C# y una **Analogía cotidiana** para facilitar la asimilación a los estudiantes.

## Requisitos

- [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/download) (o la versión de .NET 10.0 definida en tu entorno).

## Cómo ejecutar los proyectos

**Para ejecutar la Consola (Demostración de Código):**
```bash
cd BasculasOOP
dotnet run
```

**Para ejecutar la Web (Guía Visual):**
```bash
cd ExplicacionOOPWeb
dotnet run
```
Abre tu navegador en la URL que indique la consola (generalmente `http://localhost:5xxx`) para ver la explicación teórica y los ejemplos.
