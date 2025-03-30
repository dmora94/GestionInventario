import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ObtenerProductosPorId } from '../models/producto.model';
import { ObtenerProductosPorNombre } from '../models/producto.model';
import { ObtenerProducto} from '../models/producto.model';
import { ValidarInventario } from '../models/producto.model';
import { ValidarInventarioResult } from '../models/producto.model';
import { AgregarProducto } from '../models/producto.model';
import { AgregarProductoResult } from '../models/producto.model';
import { ActualizarProducto } from '../models/producto.model';
import { EliminarProducto } from '../models/producto.model';
import { Producto } from '../models/producto.model';
@Injectable({ providedIn: 'root' })
export class ProductosService {
  private apiUrl = 'http://localhost:5207/consultas';

  constructor(private http: HttpClient) {}

  dameProductos():
   Observable<Producto[]> {
    return this.http.post<Producto[]>(
      `${this.apiUrl}/obtenerProductos`, {});
  }

  dameProductosPorId(obtenerProductosPorId: ObtenerProductosPorId): 
    Observable<Producto[]> {
    return this.http.post<Producto[]>(
      `${this.apiUrl}/obtenerProductosPorId`, obtenerProductosPorId);
  }

  dameProductosPorNombre(obtenerProductosPorNombre: ObtenerProductosPorNombre): 
    Observable<Producto[]> {
    return this.http.post<Producto[]>(
      `${this.apiUrl}/obtenerProductosPorNombre`, obtenerProductosPorNombre);
  }

  dameProducto(obtenerProducto: ObtenerProducto): 
    Observable<Producto> {
    return this.http.post<Producto>(
      `${this.apiUrl}/obtenerProducto`, obtenerProducto);
  }

  validaInventario(validarInventario: ValidarInventario): 
    Observable<ValidarInventarioResult> {
    return this.http.post<ValidarInventarioResult>(
      `${this.apiUrl}/validarInventario`, validarInventario);
  }

  nuevoProducto(agregarProducto: AgregarProducto): 
    Observable<AgregarProductoResult> {
      return this.http.post<AgregarProductoResult>(
        `${this.apiUrl}/agregarProducto`, agregarProducto);        
  }

  editaProducto(actualizarProducto: ActualizarProducto):
    Observable<AgregarProductoResult> {
    return this.http.post<AgregarProductoResult>(
      `${this.apiUrl}/actualizarProducto`, actualizarProducto);
  }
  
  borrarProducto(eliminarProducto: EliminarProducto):
    Observable<any> {
    return this.http.post(
      `${this.apiUrl}/eliminarProducto`, eliminarProducto);
  }
}
