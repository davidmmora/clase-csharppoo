using PaquetesYTipos.Ejemplos;

Console.WriteLine("==========================================================");
Console.WriteLine(" 🚀 Empaquetado y Tipos Comunes en .NET");
Console.WriteLine("==========================================================");

// Capítulo 8: Trabajando con Números
TrabajandoConNumeros.Ejecutar();

// Capítulo 8: Trabajando con Texto y Regex
TrabajandoConTexto.Ejecutar();

// Capítulo 8: Colecciones (Genéricas, Inmutables, Spread Operator)
Colecciones.Ejecutar();

// Capítulo 8: Memoria Eficiente (Índices, Rangos, Spans)
MemoriaEficiente.Ejecutar();

Console.WriteLine("\n==========================================================");
Console.WriteLine(" 📦 Notas del Capítulo 7 (Empaquetado y Distribución):");
Console.WriteLine("==========================================================");
Console.WriteLine("- Este proyecto está configurado con <PublishAot>true</PublishAot> en el .csproj");
Console.WriteLine("- Usa características de Preview activadas con <EnablePreviewFeatures>true</EnablePreviewFeatures>");
Console.WriteLine("- Las validaciones Regex aprovechan Source Generators [GeneratedRegex]");
Console.WriteLine("==========================================================");
