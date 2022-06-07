import { SaleOrderItemForCreation } from "./sale-order-item-for-creation";

export class SaleOrderForCreation {
    constructor(init?: Partial<SaleOrderForCreation>){
        this.customerId =init.customerId
        this.warehouseId =init.warehouseId
        this.description =init.description
        init.saleOrderItems.forEach(saleOrderItem=> {
            this.saleOrderItems.push(new SaleOrderItemForCreation(saleOrderItem))
        });
        this.isActive=init.isActive
    }

    customerId :number;
	warehouseId :number;
	description :string;
	saleOrderItems: SaleOrderItemForCreation[]=[];
	isActive:boolean;
}