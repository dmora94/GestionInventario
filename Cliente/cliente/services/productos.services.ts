import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../models/producto.model';

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
