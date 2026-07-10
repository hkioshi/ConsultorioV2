import type { Paciente } from "../Model/Paciente";
import { ValidacaoService } from "./ValidacaoService";
import { DataBaseService } from "./DataBaseService";

export class PacienteService {
  Deletar(paciente: Paciente): void {
    alert("quaq")
  }
  Salvar(){
    alert("quaq")

  }

  async pesquisar(value: string, filtro: string, setPacientes: (pacientes: Paciente[]) => void): Promise<void> {   
    if(filtro === "nome")     
        setPacientes(await DataBaseService.pesquisarPorNome(value));
    
    if(filtro === "id" && ValidacaoService.validateId(value)) 
        setPacientes(await DataBaseService.pesquisarPorId(value));
    
    if(filtro === "cpf" && ValidacaoService.validateCpf(value)) 
        setPacientes(await DataBaseService.pesquisarPorCpf(value));
  }
}