import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ListTransaccionesComponent } from './list-trasacciones/list-transacciones.component';
import { FormTransaccionComponent } from './from-transaccion/from-transacion.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', component: ListTransaccionesComponent },
      { path: 'nueva', component: FormTransaccionComponent },
      { path: 'editar/:id', component: FormTransaccionComponent }
    ])
  ]
})
export class TransaccionesModule { }
