export default class NavigationService {
    private static instance: NavigationService;

    private constructor() {}

    static get Instance() {
        if (!NavigationService.instance) {
            NavigationService.instance = new NavigationService();
        }

        return NavigationService.instance;
    }

    navegar(nome: React.JSX.Element) {
        console.log(nome);
    }
}