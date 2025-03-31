import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { TransaccionesService } from '../../../services/transacciones.services';
import { ProductosService } from '../../../services/productos.services';
import { Transaccion } from '../../../models/transaccion.model';
import { Producto } from '../../../models/producto.model';
import { ObtenerTransaccionesPorIdProducto } from '../../../models/transaccion.model';
import { ElimimarTransaccion } from '../../../models/transaccion.model';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-transacciones',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
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
      let obtenerTransaccionesPorIdProducto: ObtenerTransaccionesPorIdProducto = {
        IdProducto: this.idProductoSeleccionado,
        IdTransaccion: 5,
        Ascendente: true,
        NumeroRegistros: 0
      };
      this.transaccionesService.dameTransaccionesPorIdProducto(obtenerTransaccionesPorIdProducto).subscribe((data) => {
        this.transacciones = data;
      });
    }
  }

  eliminarTransaccion(idTransaccion: number) {
    if (confirm('¿Estás seguro de eliminar esta transacción?')) {
      let eliminarTransaccion: ElimimarTransaccion = {
        IdTransaccion: this.idProductoSeleccionado,
        
      }
      this.transaccionesService.borrarTransaccion(eliminarTransaccion).subscribe(() => {
        this.obtenerTransacciones();
      });
    }
  }
}
