import { PacienteService } from '../Services/PacienteService';
import '../Style/AdiconarPaciente.css'

const _service = new PacienteService();

export default function AdicionarPaciente()
{
    return (
    
    <div className="Formulario">
        <div className="CabecalhoFormulario">
            <div className="header-content">
                      <h1>Pacientes</h1>
                      <p>Gerencie seus pacientes aqui.</p>
                    </div>
                    <div>
                      <button onClick={() => _service.Salvar()} className="btn btn-primary">Salvar Paciente</button>
                      
            </div>
            
        </div>
        <div className="CorpoFormulario">
            {/* Dados Pessoais */}
            <div className="w-[380px] rounded-xl border bg-white p-5">
                <h2 className="mb-4 text-lg font-semibold">Dados Pessoais</h2>
                <div className="grid grid-cols-2 gap-3">

                    <div className="col-span-2">
                    <label>Nome completo</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>CPF</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>RG</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Data de nascimento</label>
                    <input type="date" className="input" />
                    </div>

                    <div></div>

                    <div>
                    <label>Gênero</label>
                    <select className="input">
                        <option>Masculino</option>
                        <option>Feminino</option>
                        <option>Outro</option>
                    </select>
                    </div>

                    <div>
                    <label>Estado civil</label>
                    <select className="input">
                        <option>Solteiro(a)</option>
                        <option>Casado(a)</option>
                        <option>Divorciado(a)</option>
                        <option>Viúvo(a)</option>
                    </select>
                    </div>

                </div>
            </div>

            {/* Contato */}
            <div className="w-[380px] rounded-xl border bg-white p-5">
                <h2 className="mb-4 text-lg font-semibold">Contato e Endereço</h2>

                <div className="grid grid-cols-2 gap-3">

                    <div>
                    <label>CEP</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Número</label>
                    <input type="text" className="input" />
                    </div>

                    <div className="col-span-2">
                    <label>Logradouro</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Complemento</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Bairro</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Cidade</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Estado</label>
                    <select className="input">
                        <option>SP</option>
                        <option>RJ</option>
                        <option>MG</option>
                        <option>RS</option>
                        <option>PR</option>
                        <option>SC</option>
                        <option>BA</option>
                        <option>GO</option>
                        <option>DF</option>
                        <option>PE</option>
                        <option>CE</option>
                        <option>AM</option>
                        <option>PA</option>
                        <option>MT</option>
                        <option>MS</option>
                        <option>ES</option>
                        <option>RN</option>
                        <option>PB</option>
                        <option>AL</option>
                        <option>PI</option>
                        <option>SE</option>
                        <option>MA</option>
                        <option>TO</option>
                        <option>RO</option>
                        <option>AC</option>
                        <option>AP</option>
                        <option>RR</option>
                    </select>
                    </div>

                    <div>
                    <label>Telefone</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>E-mail</label>
                    <input type="email" className="input" />
                    </div>

                </div>
            </div>

            {/* Informações adicionais */}
            <div className="w-[380px] rounded-xl border bg-white p-5">
                <h2 className="mb-4 text-lg font-semibold">Informações Adicionais</h2>

                <div className="grid grid-cols-2 gap-3">

                    <div>
                    <label>Profissão</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Preferência de horário</label>
                    <input type="text" className="input" />
                    </div>

                    <div className="col-span-2">
                    <label>Observações</label>
                    <textarea className="input min-h-28"></textarea>
                    </div>

                    <div>
                    <label>Nome do pai</label>
                    <input type="text" className="input" />
                    </div>

                    <div>
                    <label>Nome da mãe</label>
                    <input type="text" className="input" />
                    </div>

                    <div className="col-span-2 flex items-center gap-2">
                    <input type="checkbox" id="lembretes" />
                    <label htmlFor="lembretes">
                        Quero receber lembretes
                    </label>
                    </div>

                </div>
            </div>
        </div>
    </div>
  );
}