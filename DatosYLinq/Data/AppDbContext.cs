using Microsoft.EntityFrameworkCore;
using DatosYLinq.Models;

namespace DatosYLinq.Data;

public class AppDbContext : DbContext
{
    public DbSet<ApodEntity> Apods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configuramos SQLite para este ejemplo (se crea un archivo local)
        optionsBuilder.UseSqlite("Data Source=nasa_data.db");
    }
}