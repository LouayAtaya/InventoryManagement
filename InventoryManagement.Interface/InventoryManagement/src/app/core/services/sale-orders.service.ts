import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SaleOrder, SaleOrderForCreation, SaleOrderForUpdate, SaleOrderStatus } from '../models';

@Injectable()
export class SaleOrdersService {

  baseUrl=environment.baseUrl;

  saleOrderStatusMap=new Map<Number,string>([
    [SaleOrderStatus.Incomplet,'غير مكتمل'],
    [SaleOrderStatus.Pending,'قيد التدقيق'],
    [SaleOrderStatus.Approved,' تمت الموافقة'],
    [SaleOrderStatus.Rejected,' تم الرفض']
  ])


  constructor(private http: HttpClient) { }

  addSaleOrder(saleOrderForCreation:SaleOrderForCreation): Observable<SaleOrder> {
    
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(saleOrderForCreation);

    return this.http.post<SaleOrder>(this.baseUrl + 'saleOrders', body,{'headers':headers});
  }

  GetSaleOrders():Observable<SaleOrder[]>{
    return this.http.get<SaleOrder[]>(this.baseUrl+"saleOrders");
  }

  GetSaleOrderDetails(id:number):Observable<SaleOrder>{
    return this.http.get<SaleOrder>(this.baseUrl+"saleOrders/"+id);
  }

  UpdateSaleOrder(id:number, saleOrderForUpdate:SaleOrderForUpdate):Observable<any>{
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=JSON.stringify(saleOrderForUpdate);

    return this.http.put<any>(this.baseUrl + 'saleOrders/'+id, body,{'headers':headers})
  }

  getSaleOrderStatus(status:SaleOrderStatus){
    return this.saleOrderStatusMap.get(status)
  }

  UpdateSaleOrderStatus(id:number, status:SaleOrderStatus):Observable<any>{
    const headers = { 'Content-Type': 'application/json','Accept':'application/json'}  
    const body=null;

    return this.http.put<any>(this.baseUrl + 'saleOrders/'+id+"/status/"+status, body)
  }
}
