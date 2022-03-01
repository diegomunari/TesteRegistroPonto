import { Component, OnInit } from '@angular/core';
import { Colaborador } from '../../domain/colaborador';
import { ColaboradorService } from '../../services/colaborador.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-colaboradores',
  templateUrl: './colaboradores.component.html',
  styleUrls: ['./colaboradores.component.css']
})
export class ColaboradoresComponent implements OnInit {

  colaboradores: Colaborador[] = [];

  form: FormGroup = this.buildForm();

  salvou: boolean = false;
  mostraMsgErro: boolean = false;
  msgErro: string;

  constructor(
    private colaboradorS: ColaboradorService) { }

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

  salvar() {

    let colaborador = {
      Nome: this.form.get("nome").value
    }
    console.log((colaborador))
    this.colaboradorS.post(colaborador)
      .then(() => {
        this.salvou = true
        this.getAllColaboradores()
      })
      .catch((error) => {
        this.mostraMsgErro = true
        this.msgErro = error['error'].message
      })
  }

  buildForm() {
    return new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('', Validators.compose([
        Validators.required,
        Validators.maxLength(100)
      ]))
    })
  }
}
