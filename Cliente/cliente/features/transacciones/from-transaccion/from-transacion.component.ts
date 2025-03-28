import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransaccionesService } from '../../../core/services/transacciones.service';
import { ProductosService } from '../../../core/services/productos.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Producto } from '../../../core/models/producto.model';
import { Transaccion } from '../../../core/models/transaccion.model';

@Component({
  selector: 'app-form-transaccion',
  templateUrl: './form-transaccion.component.html',
  styleUrls: ['./form-transaccion.component.css']
})
export class FormTransaccionComponent implements OnInit {
  form: FormGroup;
  productos: Producto[] = [];
  tiposTransaccion = ['COMPRA', 'VENTA'];
  esEdicion = false;
  idTransaccion?: number;
  cantidadOriginal = 0;

  constructor(
    private fb: FormBuilder,
    private transaccionesService: TransaccionesService,
    private productosService: ProductosService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      idProducto: [null, Validators.required],
      fecha: ['', Validators.required],
      tipoTransaccion: ['', Validators.required],
      cantidad: [0, Validators.required],
      precioUnitario: [0, Validators.required],
      precioTotal: [0, Validators.required],
      detalle: ['']
    });
  }

  ngOnInit(): void {
    this.cargarProductos();
    this.idTransaccion = Number(this.route.snapshot.paramMap.get('id'));
    
    if (this.idTransaccion) {
      this.esEdicion = true;
      this.cargarTransaccion();
    }
  }

  cargarProductos() {
    this.productosService.obtenerProductos().subscribe((data) => {
      this.productos = data;
    });
  }

  cargarTransaccion() {
    this.transaccionesService.obtenerTransaccionesPorIdProducto(this.idTransaccion!).subscribe((transaccion) => {
      this.form.patchValue(transaccion);
      this.cantidadOriginal = transaccion.cantidad;
    });
  }

  calcularPrecioTotal() {
    const cantidad = this.form.controls['cantidad'].value;
    const precioUnitario = this.form.controls['precioUnitario'].value;
    this.form.controls['precioTotal'].setValue(cantidad * precioUnitario);
  }

  validarStock() {
    const cantidadNueva = this.form.controls['cantidad'].value;
    const diferencia = cantidadNueva - this.cantidadOriginal;

    if (this.form.controls['tipoTransaccion'].value === 'VENTA' && diferencia < 0) {
      const idProducto = this.form.controls['idProducto'].value;
      const stockDisminuir = Math.abs(diferencia);

      this.transaccionesService.validarInventario(idProducto, stockDisminuir).subscribe((esValido) => {
        if (!esValido) {
          alert('No hay suficiente stock para la venta.');
          return;
        }
        this.guardarTransaccion();
      });
    } else {
      this.guardarTransaccion();
    }
  }

  guardarTransaccion() {
    if (this.esEdicion) {
      this.transaccionesService.actualizarTransaccion(this.form.value).subscribe(() => {
        alert('Transacción actualizada');
        this.router.navigate(['/transacciones']);
      });
    } else {
      this.transaccionesService.agregarTransaccion(this.form.value).subscribe(() => {
        alert('Transacción guardada');
        this.router.navigate(['/transacciones']);
      });
    }
  }
}
