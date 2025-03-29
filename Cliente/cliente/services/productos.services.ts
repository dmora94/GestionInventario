import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ObtenerProductosPorId } from '../models/producto.model' //'../models/producto.model';
import { ObtenerProductosPorNombre } from '../models/producto.model';
import { ObtenerProducto} from '../models/producto.model';
import { ValidarInventario } from '../models/producto.model';
import { AgregarProducto } from '../models/producto.model';
import { ActualizarProducto } from '../models/producto.model';
import { EliminarProducto } from '../models/producto.model';
@Injectable({ providedIn: 'root' })
export class ProductosService {
  private apiUrl = 'http://localhost:5207/consultas';

  constructor(private http: HttpClient) {}

  obtenerProductos(): Observable<Producto[]> {
    return this.http.post<Producto[]>(`${this.apiUrl}/obtenerProductos`, {});
  }

  agregarProducto(producto: Producto): Observable<any> {
    return this.http.post(`${this.apiUrl}/agregarProducto`, producto);
  }
}
