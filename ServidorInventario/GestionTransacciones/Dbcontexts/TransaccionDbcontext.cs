using GestionTransacciones.Modelos;

using Microsoft.EntityFrameworkCore;

namespace GestionTransacciones.Dbcontexts
{
    public class TransaccionDbcontext : DbContext
    {
        public TransaccionDbcontext(DbContextOptions options) : base(options) { }

        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaccion>()
                .ToTable("TRANSACCIONES", "INVENTARIO");

            base.OnModelCreating(modelBuilder);
        }
    }
}
