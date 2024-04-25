import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarPacienteComponent } from './pages/paciente/cadastrar-paciente/cadastrar-paciente.component';
import { ListarPacienteComponent } from './pages/paciente/listar-paciente/listar-paciente.component';

const routes: Routes = [
  {
    path: "",
    component: ListarPacienteComponent
  },
  {
    path: "pages/paciente/listar",
    component: ListarPacienteComponent
  },
  {
    path: "pages/paciente/cadastrar",
    component: CadastrarPacienteComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
