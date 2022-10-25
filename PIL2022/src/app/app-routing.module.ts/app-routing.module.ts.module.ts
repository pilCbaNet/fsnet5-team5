import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcercaDeComponent } from '../componentes/acerca-de/acerca-de.component';
import { LandingComponent } from '../componentes/landing/landing.component';
import { QuienesSomosComponent } from '../componentes/quienes-somos/quienes-somos.component';
import { MovimientosComponent } from '../componentes/movimientos/movimientos.component';

const routes: Routes = [
  {path: 'home', component: LandingComponent},
  {path: 'quienes-somos', component: QuienesSomosComponent},
  {path: 'acerca-de', component: AcercaDeComponent},
  {path: 'movimientos', component: MovimientosComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: '**', redirectTo: '/home', pathMatch: 'full'},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
