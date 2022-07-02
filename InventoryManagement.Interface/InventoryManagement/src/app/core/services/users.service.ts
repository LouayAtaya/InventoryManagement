import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticatedResponse } from '../models/AuthenticatedResponse';
import { LoginUser } from '../models/login-user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl=environment.baseUrl;

  constructor(private http: HttpClient) { }

  login(loginUser:LoginUser): Observable<AuthenticatedResponse> {
    
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(loginUser);

    return this.http.post<AuthenticatedResponse>(this.baseUrl + 'users/login', body,{'headers':headers});
  }

 
}
