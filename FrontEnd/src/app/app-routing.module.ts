import { PontoListComponent } from './components/pontos/ponto-list/ponto-list.component';
import { PontoFormComponent } from './components/pontos/ponto-form/ponto-form.component';
import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ColaboradoresComponent } from './components/colaboradores/colaboradores.component';

const routes: Routes = [
  { path: 'Colaboradores', component: ColaboradoresComponent },
  { path: 'Pontos' , component: PontoFormComponent},
  { path: 'Pontos/Busca', component: PontoListComponent}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
