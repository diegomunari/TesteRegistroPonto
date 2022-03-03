import { BaseService } from './base.service';
import { Injectable } from '@angular/core';

@Injectable()
export class PontoService {

  urlAPI = 'Pontos'

  constructor(public base: BaseService) { }

  getAll() {
    return this.base.getAll(this.urlAPI).toPromise();
  }

  getByColaborador(id: any) {
    return this.base.getById(this.urlAPI, id).toPromise();
  }

  post(data: any) {
    return this.base.post(this.urlAPI, data).toPromise();
  }

  getByDataColaborador(consulta) {
    return this.base.post(this.urlAPI + "/Busca/", consulta).toPromise();
  }
}
