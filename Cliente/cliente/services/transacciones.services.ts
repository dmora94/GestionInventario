import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ObtenerTransaccionesPorIdProducto } from '../models/transaccion.model';
import { ObtenerTransaccionesPorFiltros } from '../models/transaccion.model';
import { ObtenerTransaccion } from '../models/transaccion.model';
import { AgregarTransaccion } from '../models/transaccion.model';
import { ActualizarTransaccion } from '../models/transaccion.model';
import { AgregarTransaccionResult } from '../models/transaccion.model';
import { ElimimarTransaccion } from '../models/transaccion.model';
import { Transaccion } from '../models/transaccion.model';


@Injectable({ providedIn: 'root' })
export class TransaccionesService {
  private apiUrl = 'http://localhost:5076/consultas';

  constructor(private http: HttpClient) {}

  dameTransaccionesPorIdProducto(obtenerTransaccionesPorIdProducto: ObtenerTransaccionesPorIdProducto): 
    Observable<Transaccion[]> {
    return this.http.post<Transaccion[]>(
      `${this.apiUrl}/obtenerTransaccionesPorIdProducto`, obtenerTransaccionesPorIdProducto);
  }

  dameTransaccionesPorFiltros(obtenerTransaccionesPorFiltros: ObtenerTransaccionesPorFiltros): 
    Observable<Transaccion[]> {
    return this.http.post<Transaccion[]>(
      `${this.apiUrl}/obtenerTransaccionesPorFiltros`, obtenerTransaccionesPorFiltros);
  }

  dameTransaccion(obtenerTransaccion: ObtenerTransaccion): 
    Observable<Transaccion> {
    return this.http.post<Transaccion>(
      `${this.apiUrl}/obtenerTransaccion`, obtenerTransaccion);
  }

  nuevaTransaccion(agregarTransaccion: AgregarTransaccion):
   Observable<AgregarTransaccionResult> { 
    return this.http.post<AgregarTransaccionResult>(
      `${this.apiUrl}/agregarTransaccion`, agregarTransaccion);
  }

  editaTransaccion(actualizarTransaccion: ActualizarTransaccion):
   Observable<any> {
    return this.http.post(
      `${this.apiUrl}/actualizarTransaccion`, actualizarTransaccion);
  }

  borrarTransaccion(eliminarTransaccion: ElimimarTransaccion):
   Observable<any> {
    return this.http.post(
      `${this.apiUrl}/eliminarTransaccion`, eliminarTransaccion);
  }
}