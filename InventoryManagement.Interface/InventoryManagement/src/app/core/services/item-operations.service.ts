import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ItemOperationForCreation } from '../models';
import { ItemOperation } from '../models/item-operation';
import { ItemOperationForUpdate } from '../models/item-operation-for-update';
import { ItemOperationType } from '../models/enums/item-operation-type';

@Injectable()
export class ItemOperationsService {
  
  baseUrl=environment.baseUrl;

  itemOperationTypesMap=new Map<ItemOperationType,string>([
    [ItemOperationType.Addition,' إضافة'],
    [ItemOperationType.Exit,' إخراج'],
    [ItemOperationType.Lost,'  مفقود'],
    [ItemOperationType.Return,'  مرتجع'],
    [ItemOperationType.Transfer,'  نقل']
  ])


  constructor(private http: HttpClient) { }

  addItemOperation(itemOperationForCreation:ItemOperationForCreation): Observable<ItemOperation> {
    
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(itemOperationForCreation);

    return this.http.post<ItemOperation>(this.baseUrl + 'itemOperations', body,{'headers':headers});
  }

  getItemOperations():Observable<ItemOperation[]>{
    return this.http.get<ItemOperation[]>(this.baseUrl+"itemOperations");
  }

  getItemOperationDetails(id:number):Observable<ItemOperation>{
    return this.http.get<ItemOperation>(this.baseUrl+"itemOperations/"+id);
  }

  getItemOperationByItem(itemId:number):Observable<ItemOperation[]>{
    return this.http.get<ItemOperation[]>(this.baseUrl+"itemOperations/item/"+itemId);
  }

  updateItemOperation(id:number, itemOperationForUpdate:ItemOperationForUpdate):Observable<any>{
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(itemOperationForUpdate);

    return this.http.put<any>(this.baseUrl + 'itemOperations/'+id, body,{'headers':headers})
  }

  getItemOperationType(type:ItemOperationType){
    return this.itemOperationTypesMap.get(type);
  }
}
