import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Transaccion } from '../models/transaccion.model';

@Injectable({ providedIn: 'root' })
export class TransaccionesService {
  private apiUrl = 'http://localhost:5076/consultas';

  constructor(private http: HttpClient) {}

  obtenerTransacciones(): Observable<Transaccion[]> {
    return this.http.post<Transaccion[]>(`${this.apiUrl}/obtenerTransaccionesPorFiltros`, {});
  }

  agregarTransaccion(transaccion: Transaccion): Observable<any> {
    return this.http.post(`${this.apiUrl}/agregarTransaccion`, transaccion);
  }
}
