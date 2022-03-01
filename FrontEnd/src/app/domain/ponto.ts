import { Colaborador } from './colaborador';
import { Entity } from './entity'

export class Ponto extends Entity {
  colaborador: Colaborador
  entradaSaida: boolean
  dataHora: Date
}
