namespace GestionProductos.Endpoints;

public class ObtenerProductosPorId
{
    public int Id { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }

}

public class ObtenerProductosPorNombre
{
    public string Nombre { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }
}

public class ValidarInventario
{
    public int IdProducto { get; set; }
    public int StockDisminuir { get; set; }
}

