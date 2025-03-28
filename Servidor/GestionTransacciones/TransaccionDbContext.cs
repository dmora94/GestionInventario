using Microsoft.EntityFrameworkCore;

namespace GestionTransacciones;

public class TransaccionDbContext : DbContext
{
    public TransaccionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Transaccion> Transacciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaccion>()
            .ToTable("TRANSACCIONES", "INVENTARIO", tb => tb.HasTrigger("TG_ACTUALIZARSTOCKNUEVATRANSACCION"));

        base.OnModelCreating(modelBuilder);
    }
}
