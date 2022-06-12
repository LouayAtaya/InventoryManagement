import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SaleOrdersService } from '../../../core/services/sale-orders.service';
import { SaleOrder } from '../../../core/models/sale-order';
import { ContentHeaderService, SaleOrderStatus } from 'src/app/core';

@Component({
  selector: 'app-sale-order-details',
  templateUrl: './sale-order-details.component.html',
  styleUrls: ['./sale-order-details.component.css']
})
export class SaleOrderDetailsComponent implements OnInit {

  saleOrderId:number;
  saleOrder:SaleOrder;

  isIncompletStatus:boolean;
  isRejectedStatus:boolean;
  isPendingStatus:boolean;
  isApprovedStatus:boolean;

  constructor(private saleOrdersService:SaleOrdersService, private route:ActivatedRoute, private router:Router,private contentHeaderService:ContentHeaderService) { 
    this.saleOrder=new SaleOrder();
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params=>{
        this.saleOrderId=Number.parseInt(params.get("id"))
        this.getSaleOrderDetails(this.saleOrderId);
      }
    )
  }

  getSaleOrderDetails(id:number){
    this.saleOrdersService.GetSaleOrderDetails(id).subscribe(
      data=>{
        this.saleOrder=data;  

        this.contentHeaderService.setMainHeaderTitle("طلب مبيعات: #"+this.saleOrder.id)
        this.isApprovedStatus=data.saleOrderStatus==SaleOrderStatus.Approved
        this.isRejectedStatus=data.saleOrderStatus==SaleOrderStatus.Rejected
        this.isPendingStatus=data.saleOrderStatus==SaleOrderStatus.Pending
        this.isIncompletStatus=data.saleOrderStatus==SaleOrderStatus.Incomplet

      },
      error=>{
        this.router.navigateByUrl("404")

      }
    )
  }

  approveSaleOrder(){
    this.saleOrdersService.UpdateSaleOrderStatus(this.saleOrderId,SaleOrderStatus.Approved).subscribe(
      data=>{
        alert("Approved")
      },
      error=>{
        console.log(error)
        alert("Error")

      }
    )
  }

  rejectSaleOrder(){
    this.saleOrdersService.UpdateSaleOrderStatus(this.saleOrderId,SaleOrderStatus.Rejected).subscribe(
      data=>{
        alert("Rejected")
      },
      error=>{
        console.log(error)
        alert("Error")

      }
    )
  }

  getSaleOrderStatus(status:SaleOrderStatus){
    return this.saleOrdersService.getSaleOrderStatus(status);
  }

}
