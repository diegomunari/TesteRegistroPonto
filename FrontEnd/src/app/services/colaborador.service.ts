import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";

@Injectable()
export class ColaboradorService {

  urlAPI = 'Colaboradores'

  constructor(public base: BaseService) { }

  getAll() {
    return this.base.getAll(this.urlAPI).toPromise();
  }

  getById(id: any) {
    return this.base.getById(this.urlAPI, id).toPromise();
  }

  post(data: any) {
    return this.base.post(this.urlAPI, data).toPromise();
  }


}
