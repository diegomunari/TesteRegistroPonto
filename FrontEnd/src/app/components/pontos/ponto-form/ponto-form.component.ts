import { Colaborador } from './../../../domain/colaborador';
import { PontoService } from './../../../services/ponto.service';
import { ColaboradorService } from './../../../services/colaborador.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Ponto } from 'src/app/domain/ponto';

@Component({
  selector: 'app-ponto-form',
  templateUrl: './ponto-form.component.html',
  styleUrls: ['./ponto-form.component.css']
})
export class PontoFormComponent implements OnInit {

  form: FormGroup = this.buildForm()
  pontos: Ponto[] = []
  colaboradores: Colaborador[] = []

  salvou: boolean = false;
  mostraMsgErro: boolean = false;
  msgErro: string;

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
        console.log(res)
      })
  }

  salvar() {

    console.log(this.form.get("colaborador").value)

    let ponto = {
      datahora : this.form.get("data").value + "T" + this.form.get("hora").value + ":00",
      entradasaida: this.form.get("entradaSaida").value,
      colaborador: this.colaboradores.find(x => x.id == this.form.get("colaborador").value)
    }
    console.log(ponto)

    // this.pontoS.post(ponto)
    //   .then(() => {
    //     this.salvou = true
    //   })
    //   .catch((error) => {
    //     this.mostraMsgErro = true
    //     this.msgErro = error['error'].message
    //   })
  }

  buildForm() {
    return new FormGroup({
      id: new FormControl(''),
      colaborador: new FormControl('', Validators.compose([
        Validators.required
      ])),
      data: new FormControl('', Validators.compose([
        Validators.required
      ])),
      hora: new FormControl('', Validators.compose([
        Validators.required
      ])),
      entradaSaida: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })
  }
}
