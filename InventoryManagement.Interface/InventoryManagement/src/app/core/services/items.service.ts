import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Item } from '../models';

@Injectable()
export class ItemsService {

  baseUrl=environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetItems():Observable<Item[]>{
    return this.http.get<Item[]>(this.baseUrl+"items");
  }
}
