import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ItemCategory } from '../models';
import { ItemCategoryForCreation } from '../models';

@Injectable()
export class ItemCategoriesService {

  baseUrl=environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetItemCategories():Observable<ItemCategory[]>{
    return this.http.get<ItemCategory[]>(this.baseUrl+"itemCategories");
  }

  addItemCategory(itemCategoryForCreation:ItemCategoryForCreation): Observable<ItemCategory> {
    var formData=this.formDataCreator(itemCategoryForCreation);
    return this.http.post<ItemCategory>(this.baseUrl + 'itemCategories', formData)
  }

  formDataCreator(model): FormData{

    var formData= new FormData();
    for (let key of Object.keys(model)) {
      let value = model[key];


      if(value instanceof Array && value !=null && value.length!=0  ){
       
       

        for(let i=0;i<value.length;i++){
          
          for (const subKey of Object.keys(value[i])) {
            
            let subvalue = value[i][subKey];
            let key1=key+"["+i+"]["+subKey+"]"
           
            formData.append(key1, subvalue);
          }
        }
        
      }
      else{
        formData.append(key, value);
      }
    }

    return formData;
  }

}


