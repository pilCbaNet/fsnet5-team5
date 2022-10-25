import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class DepositoService {
private readonly url: string = "http://localhost:3010";
constructor(private http: HttpClient) { 
}
getUsers():Observable<any>{
  return this.http.get(this.url + "/users");
}
}
