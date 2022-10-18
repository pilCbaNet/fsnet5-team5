import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuienesSomosComponent } from '../componentes/quienes-somos/quienes-somos.component';
const routes: Routes = [
  {path: 'quienes-somos', component: QuienesSomosComponent},
  //redirect nos sirve cuando 
  {path: '', redirectTo: '/home', pathMatch: 'full'}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
