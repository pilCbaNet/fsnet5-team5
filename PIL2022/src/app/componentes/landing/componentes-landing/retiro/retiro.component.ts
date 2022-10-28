import { Component, OnInit } from '@angular/core';
import * as historyApiFallback from 'connect-history-api-fallback';
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
  movimiento: object = {};

  constructor(private service: RetiroService) {}

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(): void {
    this.service.getUsers().subscribe((data) => {
      this.users = data;
      this.userActual = this.users.find((data) => this.usuario === data.email);
    });
  }
  retirar() {
    this.userActual.monto -= this.monto;
    this.agregarMovimiento();
    try {
      this.service.putUsers(this.userActual).subscribe((data) => {
        this.isLoading = false;
        this.response = true;
        location.reload();
      });
    } catch {
      this.isLoading = false;
      this.response = false;
    }
  }
  agregarMovimiento() {
    const date = new Date();
    const fecha = `${date.getDate()}/${date.getMonth()}/${date.getFullYear()}`;
    const hora = `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;

    this.movimiento = {
      monto: this.monto,
      fecha: fecha,
      hora: hora,
      moneda: 'pesos',
      tipo: 'retiro',
      email: this.userActual.email,
    };
    this.userActual.movimientos.push(this.movimiento);
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
