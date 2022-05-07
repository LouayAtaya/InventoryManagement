export class WarehouseItemForCreation {
    constructor(init?: Partial<WarehouseItemForCreation>)
    {
        this.warehouseId=init.warehouseId
        this.quantity=init.quantity
        //Object.assign(this,init);
    }
    warehouseId:number;
    quantity:number;
}
