import { SaleOrderItem } from './sale-order-item';
import { SaleOrderStatus } from './enums/sale-order-status';


export class SaleOrder {
    id:number;
    customerId:number;
    customerName:string;
    warehouseId:number;
    warehouseName:string;
    saleOrderStatus:SaleOrderStatus;
    description:string;
    totalAmount:number;
    totalOrderPrice:number;
    saleOrderItems:SaleOrderItem[];
    isActive:boolean;
    createdAt:Date;
    createdBy: number;
    updatedAt:Date;
    updatedBy: number;
    deActivatedAt:Date;
    deActivatedBy: number
}