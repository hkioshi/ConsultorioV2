export interface Paciente {
  id: number;
  nome: string | null;
  cpf: string;
  rg: string | null;
  dataNascimento: string;
  genero: string | null;
  estadoCivil: string | null;
  pessoaResponsavelId: number | null;
  recomendadoPorId: number | null;

  // Contato
  cep: string | null;
  logradouro: string | null;
  numero: string | null;
  complemento: string | null;
  bairro: string | null;
  cidade: string | null;
  estado: string | null;
  telefone: string;
  email: string;

  // Extra
  profissao: string | null;
  conheceuPor: number;
  observacoes: string | null;
  preferenciaHorario: string | null;
  queroReceberLembretes: boolean;
}