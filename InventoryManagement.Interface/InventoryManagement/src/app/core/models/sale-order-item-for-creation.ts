export class SaleOrderItemForCreation {

    constructor(init?: Partial<SaleOrderItemForCreation>){
        this.itemId =init.itemId
        this.price =init.price
        this.quantity =init.quantity
    }

    itemId :number;
    price :number;
    quantity :number;
}
