import type { JSX } from "react/jsx-runtime";

type Navegar = (pagina: JSX.Element) => void;

export class NavigationService {
    private static historico: JSX.Element[] = [];
    private static paginaAtual: JSX.Element;

    private static navegar: Navegar;

    static inicializar(navegar: Navegar, tela: JSX.Element) {
        this.navegar = navegar;
        this.paginaAtual = tela;
    }

    static irPara(pagina: JSX.Element): void {

    this.historico.push(this.paginaAtual);
    this.paginaAtual = pagina;

    alert(this.historico.length)
    this.navegar(pagina);
    }

    static Voltar(): void {

        alert("voltar")
        alert(this.historico.length)
        
        alert("quaqasd")
        const pagina = this.historico.pop()!;

        this.paginaAtual = pagina;
        this.navegar(pagina);
        
    }

    static VoltarAoInicio(pagina: JSX.Element): void {
        this.paginaAtual = pagina;
        this.navegar(pagina);
        this.historico = [];

    }
}