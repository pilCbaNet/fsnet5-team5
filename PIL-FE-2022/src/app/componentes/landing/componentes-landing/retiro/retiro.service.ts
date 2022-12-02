import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class RetiroService {
private readonly url: string = "http://localhost:3010";
constructor(private http: HttpClient) { 
}
getUsers():Observable<any>{
  return this.http.get(this.url + "/users");
}

putUsers(usuarioActual: any):Observable<any>{
  return this.http.put(this.url + "/users/" + usuarioActual.id, usuarioActual);
}
}