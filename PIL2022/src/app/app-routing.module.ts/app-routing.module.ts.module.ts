import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcercaDeComponent } from '../componentes/acerca-de/acerca-de.component';
import { LandingComponent } from '../componentes/landing/landing.component';
import { LoginComponent } from '../componentes/login/login.component';
import { QuienesSomosComponent } from '../componentes/quienes-somos/quienes-somos.component';
const routes: Routes = [
  {path: 'home', component: LandingComponent},
  {path: 'quienes-somos', component: QuienesSomosComponent},
  {path: 'login', component: LoginComponent},
  {path: 'acerca-de', component: AcercaDeComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
