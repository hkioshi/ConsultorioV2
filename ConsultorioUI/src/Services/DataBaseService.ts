import type { Paciente } from "../Model/Paciente";
import axios from "axios";

const api = axios.create({
    baseURL: "https://localhost:7256",
});

export class DataBaseService {
    static pesquisarPorCpf(value: string): Promise<Paciente[]> {
        return api.get(`Paciente/BuscarPorCpf/${value}`)
            .then(response => {
                alert(response.status)
                return response.data;
            })
            .catch(error => {

            console.error("Erro ao pesquisar paciente por CPF:", error);
            return [];
        });
    }
    static pesquisarPorId(value: string): Promise<Paciente[]> {
        
        return api.get(`/Paciente/BuscarPorId/${value}`)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.error("Erro ao pesquisar paciente por ID:", error);
                return [];
            });
    }
    static pesquisarPorNome(value: string): Promise<Paciente[]> {
        return api.get(`/Paciente/BuscarPorNome/${value}`)
            .then(response => {
                return response.data;
            })
            .catch(error => {
                console.error("Erro ao pesquisar paciente por nome:", error);
                return [];
            });
    }


}