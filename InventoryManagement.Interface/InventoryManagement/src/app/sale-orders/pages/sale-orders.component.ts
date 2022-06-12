import { Component, OnInit } from '@angular/core';
import { ContentHeaderService, SaleOrderStatus } from 'src/app/core';
import { SaleOrder } from '../../core/models/sale-order';
import { SaleOrdersService } from '../../core/services/sale-orders.service';

@Component({
  selector: 'app-sale-orders',
  templateUrl: './sale-orders.component.html',
  styleUrls: ['./sale-orders.component.css']
})
export class SaleOrdersComponent implements OnInit {

  saleOrders:SaleOrder[];


  constructor(private saleOrdersService:SaleOrdersService,private contentHeaderService:ContentHeaderService) { }

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("طلبات المبيعات")
    this.saleOrdersService.GetSaleOrders().subscribe(
      data=>{
        this.saleOrders=data;
      },
      error=>{

      }
    )
  }

  getSaleOrderStatus(status:SaleOrderStatus){
    return this.saleOrdersService.getSaleOrderStatus(status);
  }

}
