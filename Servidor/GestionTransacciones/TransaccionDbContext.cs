using Microsoft.EntityFrameworkCore;

namespace GestionTransacciones;

public class TransaccionDbContext : DbContext
{
    public TransaccionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Transaccion> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaccion>()
            .ToTable("TRANSACCIONES", "INVENTARIO");

        base.OnModelCreating(modelBuilder);
    }
}
