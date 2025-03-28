export interface Transaccion {
    idTransaccion?: number;
    idProducto: number;
    fecha: string;
    tipoTransaccion: 'COMPRA' | 'VENTA';
    cantidad: number;
    precioUnitario: number;
    precioTotal: number;
    detalle: string;
  }
  