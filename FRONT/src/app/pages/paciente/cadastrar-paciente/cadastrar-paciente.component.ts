import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Paciente } from 'src/app/models/paciente.models';

@Component({
  selector: 'app-cadastrar-paciente',
  templateUrl: './cadastrar-paciente.component.html',
  styleUrls: ['./cadastrar-paciente.component.css']
})
export class CadastrarPacienteComponent {

  pacienteCpf: string = "";
  pacienteNome: string = "";
  pacienteSobrenome: string = "";
  pacienteTelefone: string = "";
  pacienteNotas: string = "";
  pacienteData: string = "";
  pacienteGenero: string = ""; 

  // Opções para o menu suspenso (select)
  generoOpcoes: string[] = ["Masculino", "Feminino", "Outro"];


  constructor(private client: HttpClient,
    private router: Router) { }

  cadastrar(): void {
    let paciente: Paciente = {
      pacienteCpf: this.pacienteCpf,
      pacienteNome: `${this.pacienteNome} ${this.pacienteSobrenome}`,
      pacienteTelefone: this.pacienteTelefone,
      pacienteNotas: this.pacienteNotas,
      pacienteData: this.pacienteData,
      pacienteGenero: this.pacienteGenero
    };

    this.client.post<Paciente>
      ("http://localhost:5004/api/paciente/cadastrar", paciente)
      .subscribe({
        // A requição funcionou
        next: (paciente) => {
          this.router.navigate(['pages/paciente/listar']);
        },
        // A requição não funcionou
        error: (erro) => {
          console.log(erro);
        }
      });
  }
}
