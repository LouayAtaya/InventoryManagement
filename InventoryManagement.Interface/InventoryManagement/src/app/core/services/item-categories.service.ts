import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ItemCategory } from '../models';

@Injectable()
export class ItemCategoriesService {

  baseUrl=environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetItemCategories():Observable<ItemCategory[]>{
    return this.http.get<ItemCategory[]>(this.baseUrl+"itemCategories");
  }
}
