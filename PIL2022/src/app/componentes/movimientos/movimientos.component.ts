import { Component, OnInit } from '@angular/core';
import { MovimientoService } from './movimiento.service';

@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {
  constructor(private service: MovimientoService) { }
  usuario: any =  localStorage.getItem("tokenPrueba") || null;
  users: any[] = [];
  userActual: any; 
  montoFinal: any; 
  idMontoFinal: any = 0;
  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(): void{
    this.service.getMonto().subscribe((data) => {
      this.users = data;
      this.userActual = this.users.find((data) => this.usuario === data.email);

      console.log(this.userActual.movimientos)
     
    });
  }

}
