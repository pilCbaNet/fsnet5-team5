import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioServices } from '../usuarios.service';
import { ServicesService } from './services.service';

@Component({
  selector: 'app-configuracion',
  templateUrl: './configuracion.component.html',
  styleUrls: ['./configuracion.component.css']
})
export class ConfiguracionComponent implements OnInit {
  usuarioActual: any;
  constructor(public serviceUsuario: UsuarioServices, private servicesDesactivar: ServicesService) { }

  ngOnInit(): void {
    this.getUser();
  }
  getUser(){
    this.serviceUsuario.getUsuario().subscribe((data) => {
      this.usuarioActual = data;
      console.log(data);
    })
  }
  desactivar(){
    this.servicesDesactivar.desactivar(this.usuarioActual.idUsuario).subscribe((data) =>
    {
      console.log(data);
    })
  }

}
