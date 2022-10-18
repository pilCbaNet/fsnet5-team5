import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module.ts/app-routing.module.ts.module';
import { AppComponent } from './app.component';
import { DepositoComponent } from './componentes/deposito/deposito.component';
import { NavbarComponent } from './componentes/navbar/navbar.component';
import { MibilleteraComponent } from './componentes/mibilletera/mibilletera.component';
import { FooterComponent } from './componentes/footer/footer.component';
import { LoginComponent } from './componentes/login/login.component';
import { UltimosmovimientosComponent } from './componentes/ultimosmovimientos/ultimosmovimientos.component';
import { RegistroComponent } from './componentes/registro/registro.component';
import { RetiroComponent } from './componentes/retiro/retiro.component';
import { CotizacionComponent } from './componentes/cotizacion/cotizacion.component';
import { LandingComponent } from './componentes/landing/landing.component';

@NgModule({
  declarations: [
    AppComponent,

    DepositoComponent,
    NavbarComponent,
    MibilleteraComponent,
    FooterComponent,
    LoginComponent,
    UltimosmovimientosComponent,
    RegistroComponent,
    RetiroComponent,
    CotizacionComponent,
    LandingComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
