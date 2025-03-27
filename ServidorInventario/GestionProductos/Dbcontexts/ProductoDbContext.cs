using GestionProductos.Modelos;

using Microsoft.EntityFrameworkCore;
namespace GestionProductos.Dbcontexts;

public class ProductoDbContext : DbContext
{
    public ProductoDbContext(DbContextOptions<ProductoDbContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
}
