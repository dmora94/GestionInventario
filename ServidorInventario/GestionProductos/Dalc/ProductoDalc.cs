using Comun;

using GestionProductos.Dbcontexts;
using GestionProductos.Modelos;

using Microsoft.EntityFrameworkCore;
namespace GestionProductos.Dalc;

public class ProductoDalc
{
    private readonly ProductoDbContext _context;

    public ProductoDalc(ProductoDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> ObtenerProductosAsync() =>
        await _context.Productos.ToListAsync();

    public async Task<List<Producto>> ObtenerProductosPorIdAsync(int id,
                                                                 bool ascendente,
                                                                 int numeroRegistros)
    {
        await Task.CompletedTask;

        return
            _context
            .Productos
            .AsQueryable()
            .ConsultaPorId(id, ascendente)
            .OrderBy(x => x.Id, ascendente)
            .Take(numeroRegistros)
            .Reverse(ascendente)
            .ToList();

    }

    public async Task<List<Producto>> ObtenerProductosPorNombreAsync(string nombre,
                                                                     bool ascendente,
                                                                     int numeroRegistros)
    {
        await Task.CompletedTask;

        return
            _context
            .Productos
            .AsQueryable()
            .ConsultaPorNombre(nombre, ascendente)
            .OrderBy(x => x.Nombre, ascendente)
            .Take(numeroRegistros)
            .Reverse(ascendente)
            .ToList();

    }

    public async Task<Producto?> ObtenerProductoAsync(int id) =>
        await _context.Productos.FindAsync(id);

    public async Task<bool> ValidarInventarioAsync(int id, int stockDisminuir)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
            return false;

        if (producto.Stock <= stockDisminuir)
            return false;

        return true;
    }

    public async Task<Producto> AgregarProductoAsync(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task ActualizarProductoAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EliminarProductoAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
            return false;

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return true;
    }
}
