import type { Paciente } from "../Model/Paciente";
import { NavigationService } from "../Services/NavigationService";
import { ProntuarioService } from "../Services/ProntuarioService";
import "../Style/AdiconarPaciente.css";

const _service = new ProntuarioService();

type Props = {
    paciente: Paciente;
};

export default function Prontuario({ paciente }: Props) 
{
    return (
        <div>
            <button onClick={() => NavigationService.Voltar()} > Voltar </button>
            
            coisa
        </div>
    )
}