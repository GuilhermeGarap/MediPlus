import { Paciente } from "./paciente.models";

export interface Consulta {
    consultaId?: number;
    paciente?: Paciente;
    pacienteId?: number;
    consultaData?: string;
    consultaCriadoEm?: string;
    consultaNotas?: string;
}
