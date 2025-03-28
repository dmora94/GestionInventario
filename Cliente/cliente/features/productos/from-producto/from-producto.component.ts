import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductosService } from '../../../services/productos.services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form-producto',
  templateUrl: './from-producto.component.html',
  styleUrls: ['./form-producto.component.css']
})
export class FormProductoComponent {
  form: FormGroup;
  categorias = ['Tecnología', 'Hogar', 'Oficina'];

  constructor(private fb: FormBuilder, private productoService: ProductosService, private router: Router) {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      categoria: ['', Validators.required],
      precio: [0, Validators.required],
      stock: [0, Validators.required],
      imagen: ['']
    });
  }

  seleccionarImagen(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      this.form.controls['imagen'].setValue(reader.result);
    };
  }

  guardarProducto() {
    this.productoService.agregarProducto(this.form.value).subscribe(() => {
      alert('Producto guardado');
      this.router.navigate(['/productos']);
    });
  }
}
