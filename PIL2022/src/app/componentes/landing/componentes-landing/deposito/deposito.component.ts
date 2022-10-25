import { Component, OnInit } from '@angular/core';
import { DepositoService } from './deposito.service';
@Component({
  selector: 'app-deposito',
  templateUrl: './deposito.component.html',
  styleUrls: ['./deposito.component.css']
})
export class DepositoComponent implements OnInit {
  response: boolean = false;
  isLoading: boolean = true;
  monto: number = 0;
  usuario: any =  localStorage.getItem("tokenPrueba") || null;
  users: any[] = [];
  userActual: any; 

  constructor(private service: DepositoService) { }

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(): void{
    this.service.getUsers().subscribe((data) => {
      this.users = data;
      this.userActual = this.users.find((data) => this.usuario === data.email);
      console.log(this.userActual)
    });
  }
  depositar() {
    this.userActual.monto += this.monto;
    try{
      this.service.putMonto(this.userActual).subscribe((data) => {
        this.isLoading = false;
        this.response = true;
        location.reload();
      });
    } catch {
      this.isLoading = false;
      this.response = false;
    }
  }
  deshabilitado(): boolean {
    if (this.monto <= 0){
      return false;
    }
    return true;
  }
}
