namespace GestionProductos.Dtos;

public record ProductoDto(int Id,
                          string Nombre,
                          string Descripcion,
                          string Categoria,
                          byte[]? Imagen,
                          decimal Precio,
                          int Stock);
