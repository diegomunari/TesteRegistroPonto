import { Entity } from './entity'

export class Colaborador extends Entity {
  nome: string
  supervisor: boolean | string
}
