using DatosYLinq.Ejemplos;

Console.WriteLine("==========================================================");
Console.WriteLine(" 🗄️ EF Core, LINQ y APIs Externas");
Console.WriteLine("==========================================================");

// Ejecutamos la lógica de conexión a API y almacenamiento en EF Core
await ManejoDeDatosEFCore.Ejecutar();

// Ejecutamos la lógica de consultas usando características modernas de LINQ (incluyendo .NET 9)
ManejoDeLinq.Ejecutar();

Console.WriteLine("\n==========================================================");
Console.WriteLine(" ✅ Demostración completada.");
Console.WriteLine("==========================================================");
