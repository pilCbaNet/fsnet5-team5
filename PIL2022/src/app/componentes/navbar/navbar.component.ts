import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  usuario: any =  localStorage.getItem("tokenPrueba") || null;


  constructor() { }

  ngOnInit(): void {
  }

  cerrarSesion():void{
    localStorage.removeItem("tokenPrueba");
    location.reload();
  }


}
