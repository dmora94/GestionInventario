export interface ObtenerProductosPorId{
  Id: number;
  Ascendente: boolean;
  NumeroRegistros: number;
}

export interface ObtenerProductosPorNombre{
  Nombre: string;
  Id: number;
  Ascendente: boolean;
  NumeroRegistros: number;
}

export interface ObtenerProducto{
  Id: number
}

export interface ValidarInventario{
  IdProducto: number;
  StockDisminuir: number;
}

export interface AgregarProducto{
  Nombre: string;
  Descripcion:string;
  Categoria:string;
  Precio:number;
  Stock:number;
  Imagen:string;// Base64
  
}

export interface ActualizarProducto {
    Id: number;
    Nombre: string;
    Descripcion: string;
    Categoria: string;
    Precio: number;
    Stock: number;
    Imagen: string; // Base64
}

export interface EliminarProducto{
  IdProducto:number;
}



  