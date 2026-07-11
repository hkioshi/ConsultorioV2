export interface Paciente {
    id: number;
    nome: string;
    cpf: string;
    rg: string;
    dataNascimento: string; // DateTime vira string no JSON
    genero: string;
    estadoCivil: string;
    pessoaResponsavelId: number;
    recomendadoPorId: number;

    // Contato
    cep: string;
    logradouro: string;
    numero: string;
    complemento: string;
    bairro: string;
    cidade: string;
    estado: string;
    telefone: string;
    email: string;

    // Extra
    nomePai: string;
    nomeMae: string;
    nomeConjuge: string;
    profissao: string;
    conheceuPor: number;
    observacoes: string;
    convenio: string;
    numeroConvenio: string;
    preferenciaHorario: string;
    queroReceberLembretes: boolean;
}