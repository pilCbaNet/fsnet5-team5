import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs';
import { LoginServiceService } from 'src/app/componentes/login/service/login-service.service';
import { MibilleteraService } from './service/mibilletera.service';

@Component({
  selector: 'app-mibilletera',
  templateUrl: './mibilletera.component.html',
  styleUrls: ['./mibilletera.component.css']
})
export class MibilleteraComponent implements OnInit {
  constructor(private service: MibilleteraService) { }
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
      console.log(this.userActual)
    });
  }

}
