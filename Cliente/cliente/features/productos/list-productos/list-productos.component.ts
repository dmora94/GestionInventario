import { Component, OnInit } from '@angular/core';
import { ProductosService } from '../../../services/productos.services'
import { Producto } from '../../../models/producto.model';
import { EliminarProducto } from '../../../models/producto.model';
@Component({
  selector: 'app-list-productos',
  templateUrl: './list-productos.component.html',
  styleUrls: ['./list-productos.component.css']
})
export class ListProductosComponent implements OnInit {
  productos: Producto[] = [];

  constructor(private productosService: ProductosService) {}

  ngOnInit(): void {
    this.obtenerProductos();
  }

  obtenerProductos() {
    this.productosService.dameProductos().subscribe((data) => {
      this.productos = data;
    });
  }

  eliminarProducto(id: number) {
    if (confirm('¿Estás seguro de eliminar este producto?')) {
      let eliminarProducto : EliminarProducto = {
        IdProducto:id
      };
      this.productosService.borrarProducto(eliminarProducto).subscribe(() => {
        this.obtenerProductos();
      });
    }
  }
}
