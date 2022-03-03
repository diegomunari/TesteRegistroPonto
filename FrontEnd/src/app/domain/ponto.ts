import { Colaborador } from './colaborador';
import { Entity } from './entity'

export class Ponto extends Entity {
  colaborador: Colaborador
  entradaSaida: boolean
  dataHora: Date

  horaEntrada: string
  horaSaida: string
  data: string
  horasTrabalhadas: string
  horasTrabalhadasTotal: string
}
