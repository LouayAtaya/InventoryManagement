import { SaleOrderStatus } from "./sale-order-status";

export const  saleOrderStatusMap=new Map<Number,string>([
    [SaleOrderStatus.Incomplet,'غير مكتمل'],
    [SaleOrderStatus.Pending,'قيد التدقيق'],
    [SaleOrderStatus.Approved,' تمت الموافقة'],
    [SaleOrderStatus.Rejected,' تم الرفض']
])
