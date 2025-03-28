using GestionTransacciones.Dbcontexts;
using GestionTransacciones.Modelos;

namespace GestionTransacciones.Dalc;

public class TransaccionDalc
{
    private readonly TransaccionDbcontext _context;

    public TransaccionDalc(TransaccionDbcontext context)
    {
        _context = context;
    }

    public async Task<List<Transaccion>> ObtenerTransaccionesPorIdProductoAsync(
        int idProducto, 
        int idTransaccion, 
        bool ascendente, 
        int numeroRegistros)
    {
        await Task.CompletedTask;

        var xx =
            _context
            .Transacciones
            .AsQueryable();

        var yy = xx.ConsultaPorIdProducto(idProducto, idTransaccion, ascendente);

        return
            yy
            .OrderBy(x => x.ID, ascendente)
            .Take(numeroRegistros)
            .Reverse(ascendente)
            .ToList();
    }

    public async Task<List<Transaccion>> ObtenerTransaccionesPorFiltrosAsync(
        int idProducto,
        DateTime fecha,
        string tipoTransaccion,
        int idTransaccion,
        bool ascendente,
        int numeroRegistros)
    {
        await Task.CompletedTask;

        return
            _context
            .Transacciones
            .AsQueryable()
            .ConsultaPorFiltros(idProducto, fecha, tipoTransaccion, idTransaccion, ascendente)
            .OrderBy(x => x.ID, ascendente)
            .Take(numeroRegistros)
            .Reverse(ascendente)
            .ToList();
    }

    public async Task<Transaccion?> ObtenerTransaccionAsync(int id) =>
        await _context.Transacciones.FindAsync(id);
    public async Task<Transaccion> AgregarTransaccionAsync(Transaccion transaccion)
    {
        _context.Transacciones.Add(transaccion);
        await _context.SaveChangesAsync();
        return transaccion;
    }

    public async Task ActualizarTransaccionAsync(Transaccion transaccion)
    {
        _context.Transacciones.Update(transaccion);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EliminarTransaccionAsync(int id)
    {
        var transaccion = await _context.Transacciones.FindAsync(id);
        if (transaccion == null)
            return false;

        _context.Transacciones.Remove(transaccion);
        await _context.SaveChangesAsync();
        return true;
    }
}
