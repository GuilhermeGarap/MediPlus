import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Paciente } from 'src/app/models/paciente.models';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent {

  pacienteCpf : string = "";
  pacienteNome : string = "";
  pacienteData : string = "";
  pacienteGenero : string = "";
  pacienteTelefone : string = "";
  pacienteNotas: string = "";

  constructor(private client: HttpClient,
    private router: Router){}

  cadastrar() : void {
    let paciente : Paciente ={
      pacienteCpf : this.pacienteCpf,
      pacienteNome : this.pacienteNome,
      pacienteData : this.pacienteData,
      pacienteGenero : this.pacienteData,
      pacienteTelefone : this.pacienteData,
      pacienteNotas : this.pacienteNotas,
    };
    
    this.client.post<Paciente>
      ("http://localhost:5004/api/paciente/cadastrar", paciente)
      .subscribe({
        //A requição funcionou
        next : (paciente) => {
          this.router.navigate(['pages/paciente/listar']);
        },
        //A requição não funcionou
        error : (erro) => {
          console.log(erro);
        }
      });

  }

}