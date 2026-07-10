import { useState } from 'react';
import '../Style/App.css'
import SideBar from "./SideBar" 
import Home from './Home';
import '../Style/App.css'

function App() {

  const [tela, setTela] = useState(<Home/>);
  function MudarTela(componente: React.JSX.Element) {
    setTela(componente);
  }

  return (
    <div className="app">
      <SideBar Navegar={MudarTela} />
      {tela}
    </div>
    
  );
}

export default App;