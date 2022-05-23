import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Account } from '../models/account';
import { Observable } from 'rxjs';
import { AccountDetails } from '../models/account-details';
import { AccountForCreation } from '../models/account-for-creation';
import { AccountForUpdate } from '../models/account-for-update';

@Injectable()
export class AccountsService {

  baseUrl=environment.baseUrl;

  constructor(private http: HttpClient) { }

  GetAccounts():Observable<Account[]>{
    return this.http.get<Account[]>(this.baseUrl+"accounts");
  }

  GetAccountDetails(id:number):Observable<AccountDetails>{
    return this.http.get<AccountDetails>(this.baseUrl+"accounts/"+id);
  }

  AddAccount(accountForCreation:AccountForCreation):Observable<Account>{
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(accountForCreation);

    return this.http.post<Account>(this.baseUrl + 'accounts', body,{'headers':headers})
  }

  UpdateAccount(accountId:number, accountForUpdate:AccountForUpdate):Observable<any>{
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(accountForUpdate);
    console.log("body")
    console.log(body)
    console.log("body")

    return this.http.put<any>(this.baseUrl + 'accounts/'+accountId, body,{'headers':headers})
  }
}
