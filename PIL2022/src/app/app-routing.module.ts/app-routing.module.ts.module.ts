import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcercaDeComponent } from '../componentes/acerca-de/acerca-de.component';
import { LandingComponent } from '../componentes/landing/landing.component';
import { QuienesSomosComponent } from '../componentes/quienes-somos/quienes-somos.component';
import { DepositoComponent } from '../componentes/landing/componentes-landing/deposito/deposito.component';
import { MovimientosComponent } from '../componentes/movimientos/movimientos.component';

const routes: Routes = [
  {path: 'home', component: LandingComponent},
  {path: 'quienes-somos', component: QuienesSomosComponent},
  {path: 'acerca-de', component: AcercaDeComponent},
  {path: 'deposito', component: DepositoComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'movimientos', component: MovimientosComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
