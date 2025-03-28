using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;
using System.Transactions;

namespace GestionProductos;

public class ProductoDbContext : DbContext
{
    public ProductoDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .ToTable("PRODUCTOS", "INVENTARIO");

        base.OnModelCreating(modelBuilder);
    }
}
