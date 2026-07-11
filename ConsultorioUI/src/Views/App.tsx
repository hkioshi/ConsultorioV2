import { useEffect, useState } from 'react';
import '../Style/App.css'
import SideBar from "./SideBar" 
import Home from './Home';
import '../Style/App.css'
import { NavigationService } from '../Services/NavigationService';

function App() {
  const [tela, setTela] = useState(<Home/>);

  useEffect(() => {
    NavigationService.inicializar(setTela, tela);
  }, []);

  return (
    <div className="app">
      <SideBar />
      {tela}
    </div>
    
  );
}

export default App;