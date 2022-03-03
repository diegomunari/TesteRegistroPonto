import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Colaborador } from './../../../domain/colaborador';
import { PontoService } from './../../../services/ponto.service';
import { ColaboradorService } from './../../../services/colaborador.service';
import { Ponto } from 'src/app/domain/ponto';

@Component({
  selector: 'app-ponto-list',
  templateUrl: './ponto-list.component.html',
  styleUrls: ['./ponto-list.component.css']
})
export class PontoListComponent implements OnInit {

  form: FormGroup = this.buildForm()
  pontos: Ponto[] = []
  colaboradores: Colaborador[] = []

  constructor(private colaboradorS: ColaboradorService,
    private pontoS: PontoService) { }

  ngOnInit() {
    this.getAllColaboradores();
  }

  getAllColaboradores() {
    this.colaboradorS
    .getAll()
      .then(res => {
        this.colaboradores = res
      })
  }

  buscar() {
    let busca = {
      data : this.form.get("data").value + "-01T00:00:00",
      colaborador: this.colaboradores.find(x => x.id == this.form.get("colaborador").value),
      buscamestodo: true
    }
    console.log(busca)

    this.pontoS.getByDataColaborador(busca)
      .then((res) =>  {
        //this.salvou = true
        this.pontos = res
        console.log(this.pontos)
      })
      .catch((error) => {
        // this.mostraMsgErro = true
        // this.msgErro = error['error'].message
      })
  }

  buildForm() {
    return new FormGroup({
      id: new FormControl(''),
      colaborador: new FormControl('', Validators.compose([
        Validators.required
      ])),
      data: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })
  }
}
