import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ColaboradoresComponent } from './colaboradores.component';
import { ColaboradorService } from '../../services/colaborador.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ColaboradoresComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ColaboradorService
  ]
})
export class ColaboradoresModule { }
