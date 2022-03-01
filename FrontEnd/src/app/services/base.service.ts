import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';


@Injectable()
export class BaseService {

  urlAPI: string = '';

  constructor(
    public httpCliente: HttpClient,
    private router: Router)
  {
    this.urlAPI = environment.urlAPI;
  }

  getAll(url) {
    return this.httpCliente.get<any>(`${this.urlAPI}/${url}`);
  }

  getById(url, id) {
    return this.httpCliente.get<any>(`${this.urlAPI}/${url}/${id}`);
  }

  post(url, data) {
    return this.httpCliente.post<any>(`${this.urlAPI}/${url}`, data);
  }

}
