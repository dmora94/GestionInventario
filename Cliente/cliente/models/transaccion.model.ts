export interface ObtenerTransaccionesPorIdProducto{
  IdProducto: number;
  IdTransaccion: number;
  Ascendente: boolean;
  NumeroRegistros: number;
}

export interface ObtenerTransaccionesPorFiltros{
  IdProducto: number;
  Fecha: Date;
  TipoTransaccion: string;
  IdTransaccion: number;
  Ascendente: boolean;
  NumeroRegistros: number;
}

export interface ObtenerTransaccion{
  IdTransaccion: number;
}

export interface AgregarTransaccion{
  IdProducto: number;
  Fecha: Date;
  TipoTransaccion: string;
  Cantidad: Number;
  PrecioUnitario: number;
  PrecioTotal: number;
  Detalle: string;
}

export interface ActualizarTransaccion {
    IdTransaccion: number;
    IdProducto: number;
    Fecha: Date;
    TipoTransaccion: 'COMPRA' | 'VENTA';
    Cantidad: number;
    PrecioUnitario: number;
    PrecioTotal: number;
    Detalle: string;
  }
  