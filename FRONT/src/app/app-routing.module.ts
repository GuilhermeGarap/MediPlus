import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarProdutoComponent } from './pages/paciente/cadastrar-produto/cadastrar-produto.component';

const routes: Routes = [
  {
    path: "pages/paciente/cadastrar",
    component: CadastrarProdutoComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
