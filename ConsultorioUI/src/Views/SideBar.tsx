import Agenda from "./Agenda";
import Configuracoes from "./Configuracoes";
import Financeiro from "./Financeiro";
import Home from "./Home";
import Pacientes from "./Pacientes";
import '../Style/SideBar.css'
import { NavigationService } from "../Services/NavigationService";


function SideBar() {
  return (
      <div className="SideBar">
        <div className="SideBar-header">
          <h4>Dra. Celia Akemi Watanabe Yamauchi</h4>
        </div>
        <ul>
          <li className="SideBar-item" onClick={() => {NavigationService.VoltarAoInicio(<Home/>)}}>Home</li>
          <li className="SideBar-item" onClick={() => {NavigationService.VoltarAoInicio(<Pacientes/>)}}>Pacientes</li>
          <li className="SideBar-item" onClick={() => {NavigationService.VoltarAoInicio(<Agenda/>)}}>Agenda</li>
          <li className="SideBar-item" onClick={() => {NavigationService.VoltarAoInicio(<Financeiro/>)}}>Financeiro</li>
          <li className="SideBar-item" onClick={() => {NavigationService.VoltarAoInicio(<Configuracoes/>)}}>Configurações</li>
        </ul>
      </div>      
  )
}


export default SideBar
