import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private url: string = "https://localhost:7177/api/usuarios/baja"
  
  constructor(private http: HttpClient) { }
  
  desactivar(id: number):Observable<any>{
    return this.http.post(this.url + "/" + id, id);
  }

}
