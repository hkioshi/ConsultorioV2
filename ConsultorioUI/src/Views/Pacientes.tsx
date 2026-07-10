import React from "react";
import { PacienteService } from "../Services/PacienteService";
import type { Paciente } from "../Model/Paciente";

function Pacientes() {
  
  const pacienteService = new PacienteService();
const [pacientes, setPacientes] = React.useState<Paciente[]>([]);  return (
    <div className="pacientes-container">
      <div className="header">
        <div className="header-content">
          <h1>Pacientes</h1>
          <p>Gerencie seus pacientes aqui.</p>
        </div>
        <div>
          <button className="btn btn-primary">Adicionar Paciente</button>
        </div>
      </div>
      <form className="form">
        <input type="text" placeholder="Pesquisar paciente..." className="input-search" />
        <input type="radio" id="Id" name="filtro" value="cidade" />
        <label htmlFor="Id">ID</label>
        <input type="radio" id="Nome" name="filtro" value="nome" />
        <label htmlFor="Nome">Nome</label>
        <input type="radio" id="CPF" name="filtro" value="cpf" />
        <label htmlFor="CPF">CPF</label>

      </form>

      <div className="pacientes-list">
        <table className="table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Nome</th>
              <th>Telefone</th>
              <th>Ações</th>

            </tr>
          </thead>
          <tbody>
           
             {pacientes.map((paciente) => (
               <tr>
                  <td>{paciente.id}</td>
                  <td>{paciente.nome}</td>
                  <td>{paciente.telefone}</td>
                  <td>
                    <button className="btn btn-secondary">Editar</button>
                    <button className="btn btn-danger">Excluir</button>
                  </td>
               </tr>
            ))}
           
          </tbody>
        </table>
      </div>      
    </div>
  )
}

export default Pacientes