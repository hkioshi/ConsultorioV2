type Navegar = (pagina: React.JSX.Element) => void;
export class NavigationService
{
     private static navegar: Navegar;

    static inicializar(navegar: Navegar) {
        this.navegar = navegar;
    }

    static irPara(pagina: React.JSX.Element) : void{
        this.navegar(pagina);
    }
}