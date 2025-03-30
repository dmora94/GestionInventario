namespace GestionProductos;

public record ProductoDto(int Id,
                          string Nombre,
                          string Descripcion,
                          string Categoria,
                          string Imagen,
                          decimal Precio,
                          int Stock);

