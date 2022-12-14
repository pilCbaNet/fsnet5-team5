import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioServices {

  private url: string = "https://localhost:7177/api/usuarios"
//  usuario: any =  localStorage.getItem("tokenPrueba") || null;

  constructor(private http: HttpClient) { }
  
  getUsuario():Observable<any>{
    return this.http.get(this.url + "/" + "eyJhbGciOiJkaXIiLCJlbmMiOiJBMTI4Q0JDLUhTMjU2In0..qhe1vZWek9-kJF3d51S8zA.zfVN_kNPfDOWbzrCpMsKJ-EyJ_arNy1UAYepXvWitxU.QWB-23C6Y5GT7Xjlp2Fy9Q");
  }

}
