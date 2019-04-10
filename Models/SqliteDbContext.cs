using Microsoft.EntityFrameworkCore;

namespace C8ProyectoFinalPorEquipos.Models
{
  public class SqliteDbContext : DbContext
  {
    public DbSet<ProductoViewModel> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data source=Db/producto.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ProductoViewModel>(p =>
      {
        p.HasData(
            new ProductoViewModel { Id = 1, Nombre = "Guitarra", Precio =300.00 , Existencia = 39 }
        );
      });
      base.OnModelCreating(modelBuilder);
    }
  }
}