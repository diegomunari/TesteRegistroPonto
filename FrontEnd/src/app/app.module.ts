import { PontoModule } from './components/pontos/ponto.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderModule } from './components/header/header.module';
import { AppRoutingModule } from './app-routing.module';
import { ColaboradoresModule } from './components/colaboradores/colaboradores.module';
import { HttpClientModule } from '@angular/common/http';
import { BaseService } from './services/base.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HeaderModule,
    AppRoutingModule,
    ColaboradoresModule,
    HttpClientModule,
    PontoModule
  ],
  providers: [BaseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
