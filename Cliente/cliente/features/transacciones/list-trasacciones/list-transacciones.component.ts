import { Component, OnInit } from '@angular/core';
import { TransaccionesService } from '../../../services/transacciones.services';
import { ProductosService } from '../../../services/productos.services';
import { Transaccion } from '../../../models/transaccion.model';
import { Producto } from '../../../models/producto.model';

@Component({
  selector: 'app-list-transacciones',
  templateUrl: './list-transacciones.component.html',
  styleUrls: ['./list-transacciones.component.css']
})
export class ListTransaccionesComponent implements OnInit {
  transacciones: Transaccion[] = [];
  productos: Producto[] = [];
  idProductoSeleccionado: number = 0;

  constructor(
    private transaccionesService: TransaccionesService,
    private productosService: ProductosService
  ) {}

  ngOnInit(): void {
    this.cargarProductos();
  }

  cargarProductos() {
    this.productosService.dameProductos().subscribe((data) => {
      this.productos = data;
    });
  }

  obtenerTransacciones() {
    if (this.idProductoSeleccionado) {
      this.transaccionesService.dameTransaccionesPorIdProducto(this.idProductoSeleccionado).subscribe((data) => {
        this.transacciones = data;
      });
    }
  }

  eliminarTransaccion(idTransaccion: number) {
    if (confirm('¿Estás seguro de eliminar esta transacción?')) {
      this.transaccionesService.borrarTransaccion(idTransaccion).subscribe(() => {
        this.obtenerTransacciones();
      });
    }
  }
}
