import { Component } from '@angular/core';
import { Paciente } from 'src/app/models/paciente.models';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-listar-paciente',
  templateUrl: './listar-paciente.component.html',
  styleUrls: ['./listar-paciente.component.css']
})
export class ListarPacienteComponent {
  colunasTabela: string[] = [
    "pacienteId",
    "pacienteNome",
    "pacienteCpf",
    "pacienteData",
    "pacienteGenero",
    "pacienteTelefone",
    "pacienteNotas",
    "pacienteDeletar",
    "pacienteEditar"
  ];

  pacientes: Paciente[] = [];

  constructor(private client: HttpClient, private snackBar: MatSnackBar) {}

  //Método que é executado ao abrir um componente
  ngOnInit(): void {
    this.client
      .get<Paciente[]>("http://localhost:5004/api/paciente/listar")
      .subscribe({
        //A requição funcionou
        next: (pacientes) => {
          this.pacientes = pacientes;
        },
        //A requição não funcionou
        error: (erro) => {
          console.log(erro);
        },
      });
  }

  deletar(pacienteId: number) {
    this.client
      .delete<Paciente[]>(
        `http://localhost:5004/api/paciente/deletar/${pacienteId}`
      )
      .subscribe({
        //Requisição com sucesso
        next: (pacientes) => {
          this.pacientes = pacientes;
          this.snackBar.open("Paciente deletado com sucesso!!", "E-commerce", {
            duration: 1500,
            horizontalPosition: "right",
            verticalPosition: "top",
          });
        },
        //Requisição com erro
        error: (erro) => {
          console.log(erro);
        },
      });
  }
}


