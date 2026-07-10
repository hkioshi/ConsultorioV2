import Agenda from "./Agenda";
import Configuracoes from "./Configuracoes";
import Financeiro from "./Financeiro";
import Home from "./Home";
import Pacientes from "./Pacientes";
import '../Style/SideBar.css'


type SideBarProps = {
    Navegar: (componente: React.JSX.Element) => void;
};

function SideBar({ Navegar }: SideBarProps) {
  
  return (
    <>
      
      <div className="SideBar">
        <div className="SideBar-header">
          <h4>Dra. Celia Akemi Watanabe Yamauchi</h4>
        </div>
        <ul>
          <li className="SideBar-item" onClick={() => {Navegar(<Home/>)}}>Home</li>
          <li className="SideBar-item" onClick={() => {Navegar(<Pacientes/>)}}>Pacientes</li>
          <li className="SideBar-item" onClick={() => {Navegar(<Agenda/>)}}>Agenda</li>
          <li className="SideBar-item" onClick={() => {Navegar(<Financeiro/>)}}>Financeiro</li>
          <li className="SideBar-item" onClick={() => {Navegar(<Configuracoes/>)}}>Configurações</li>
        </ul>
      </div>
      
    </>
  )
}


export default SideBar
