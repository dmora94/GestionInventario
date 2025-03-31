import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ListProductosComponent } from './list-productos/list-productos.component';
import { FormProductoComponent } from './from-producto/from-producto.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: ListProductosComponent },
      { path: 'nuevo', component: FormProductoComponent },
      { path: 'editar/:id', component: FormProductoComponent }
    ])
  ]
})
export class ProductosModule { }
