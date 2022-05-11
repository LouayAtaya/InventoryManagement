import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Item } from '../models';
import { ItemForCreation } from '../models/item-for-creation';

@Injectable()
export class ItemsService {

  baseUrl=environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetItems():Observable<Item[]>{
    return this.http.get<Item[]>(this.baseUrl+"items");
  }

  addItem(itemForCreation:ItemForCreation): Observable<Item> {
    var formData=this.formDataCreator(itemForCreation);
    return this.http.post<Item>(this.baseUrl + 'items', formData)
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
