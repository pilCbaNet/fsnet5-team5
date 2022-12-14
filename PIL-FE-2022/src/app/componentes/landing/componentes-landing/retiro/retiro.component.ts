import { Component, OnInit } from '@angular/core';
import * as historyApiFallback from 'connect-history-api-fallback';
import { UsuarioServices } from 'src/app/componentes/usuarios.service';
import { RetiroService } from './retiro.service';
@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.css'],
})
export class RetiroComponent implements OnInit {
  response: boolean = false;
  isLoading: boolean = true;
  monto: number = 0;
  usuario: any = localStorage.getItem('tokenPrueba') || null;
  users: any[] = [];
  userActual: any;
  idUsuario: number = 0;
  retiroBody: object = {};
  movimiento: object = {};

  constructor(private service: RetiroService, private serviceUser: UsuarioServices) {}

  ngOnInit(): void {
    this.getUser();
  }
  getUser(){
    this.serviceUser.getUsuario().subscribe((data) =>
    {
        this.idUsuario = data.idUsuario;
        console.log(this.idUsuario)
    })
  }

  retirar(){
    
    this.retiroBody = {"idUsuario": this.idUsuario, "saldo": this.monto}
    this.service.retiro(this.retiroBody).subscribe((data) => {
      console.log(data);
      location.reload();
    })
  }

  deshabilitado(): boolean {
    if (this.userActual) {
      if (this.monto > this.userActual.monto || this.monto <= 0) {
        return false;
      }
    }
    return true;
  }

}
