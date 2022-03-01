import { PontoListComponent } from './ponto-list/ponto-list.component';
import { PontoService } from './../../services/ponto.service';
import { ColaboradorService } from './../../services/colaborador.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PontoFormComponent } from '../pontos/ponto-form/ponto-form.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    PontoFormComponent,
    PontoListComponent
],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ColaboradorService,
    PontoService
  ]
})
export class PontoModule { }
