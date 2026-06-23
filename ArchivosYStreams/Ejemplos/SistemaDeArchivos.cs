namespace ArchivosYStreams.Ejemplos;

public class SistemaDeArchivos
{
    public static void Ejecutar()
    {
        Console.WriteLine("\n--- 📁 Tema 1: Sistema de Archivos Multiplataforma ---");
        
        // Manejo multiplataforma
        Console.WriteLine($"Separador de directorios (OS actual): {Path.DirectorySeparatorChar}");
        Console.WriteLine($"Separador de rutas en PATH: {Path.PathSeparator}");

        // Directorios especiales
        string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string carpetaTemporal = Path.GetTempPath();
        string nombreAleatorio = Path.GetRandomFileName();
        
        Console.WriteLine($"Mis Documentos: {carpetaDocumentos}");
        Console.WriteLine($"Carpeta Temporal: {carpetaTemporal}");
        Console.WriteLine($"Nombre aleatorio de archivo: {nombreAleatorio}");

        // Administración de Unidades (Drives)
        Console.WriteLine("\n--- Unidades (Drives) ---");
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                // Convertimos bytes a Gigabytes (GB)
                long espacioLibreGB = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                Console.WriteLine($"Unidad: {drive.Name} - Espacio Libre: {espacioLibreGB} GB");
            }
        }

        // Administración de Directorios y Archivos
        Console.WriteLine("\n--- Directorios y Archivos ---");
        
        // Uso seguro de Path.Combine para unir carpetas multiplataforma
        string rutaPrueba = Path.Combine(carpetaTemporal, "Prueba_SistemaArchivos");
        
        if (!Directory.Exists(rutaPrueba))
        {
            Directory.CreateDirectory(rutaPrueba);
            Console.WriteLine($"Directorio creado: {rutaPrueba}");
        }

        string rutaArchivo = Path.Combine(rutaPrueba, "archivo_texto.txt");
        
        // Escribir un archivo rápidamente
        File.WriteAllText(rutaArchivo, "Contenido de prueba");
        
        // Extracción de metadatos con FileInfo
        FileInfo info = new FileInfo(rutaArchivo);
        Console.WriteLine($"Archivo creado: {info.Name}");
        Console.WriteLine($"Tamaño: {info.Length} bytes");
        Console.WriteLine($"Extensión: {info.Extension}");

        // Limpieza del archivo y directorio
        File.Delete(rutaArchivo);
        Directory.Delete(rutaPrueba);
        Console.WriteLine("Archivos temporales limpiados.");
    }
}