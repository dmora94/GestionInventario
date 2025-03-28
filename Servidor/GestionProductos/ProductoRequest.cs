namespace GestionProductos;

public class ObtenerProductosPorId
{
    public int Id { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }

}

public class ObtenerProductosPorNombre
{
    public string Nombre { get; set; }
    public int Id { get; set; }
    public bool Ascendente { get; set; }
    public int NumeroRegistros { get; set; }
}

public class ObtenerProducto
{
    public int Id { get; set; }
}
public class ValidarInventario
{
    public int IdProducto { get; set; }
    public int StockDisminuir { get; set; }
}


public class AgregarProducto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Imagen { get; set; }
}

public class ActualizarProducto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Imagen { get; set; }
}


public class EliminarProducto
{
    public int IdProducto { get; set; }
}

