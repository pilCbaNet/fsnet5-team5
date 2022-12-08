import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import LoginClass from '../loginClass/loginClass';


@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private url:string = "http://localhost:3010" //aca va la url de la api de login (del back)

  constructor(private http:HttpClient) { }

  login(LoginClass: LoginClass):Observable<any>{
    return this.http.post(this.url + "/users", LoginClass);
  }
  getUsers():Observable<any>{
    return this.http.get(this.url + "/users");
  }

  //metodo agregado para iniciar sesion desde el back
  iniciarSesion(login:LoginClass):Observable<any>{
    return this.http.post<any>(this.url, login)
  }
}
