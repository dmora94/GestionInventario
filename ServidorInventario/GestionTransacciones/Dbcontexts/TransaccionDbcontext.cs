using GestionTransacciones.Modelos;

using Microsoft.EntityFrameworkCore;

namespace GestionTransacciones.Dbcontexts
{
    public class TransaccionDbcontext : DbContext
    {
        public TransaccionDbcontext(DbContextOptions<TransaccionDbcontext> options) : base(options) { }

        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
