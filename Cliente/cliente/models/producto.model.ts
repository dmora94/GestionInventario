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

export interface ValidarInventarioResult{
  Resuesta: boolean;
}

export interface AgregarProducto{
  Nombre: string;
  Descripcion:string;
  Categoria:string;
  Precio:number;
  Stock:number;
  Imagen:string;// Base64
  
}


export interface AgregarProductoResult{
  IdProducto: number;
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

export interface Producto{
  Id: number;
  Nombre: string;
  Descripcion: string;
  Categoria: string;
  Imagen: string;
  Precio: number;
  Stock: number;
}



  