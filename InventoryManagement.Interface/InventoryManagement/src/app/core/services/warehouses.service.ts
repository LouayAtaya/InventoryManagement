import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {environment} from 'src/environments/environment';
import { Warehouse } from '../models';

@Injectable()
export class WarehousesService {

  
  baseUrl=environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetWarehouses():Observable<Warehouse[]>{
    return this.http.get<Warehouse[]>(this.baseUrl+"warehouses");
  }

}
