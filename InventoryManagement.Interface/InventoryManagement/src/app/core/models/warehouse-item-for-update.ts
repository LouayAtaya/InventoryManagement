export class WarehouseItemForUpdate {
    constructor(init?: Partial<WarehouseItemForUpdate>)
    {
        this.warehouseId=init.warehouseId
        this.itemId=init.itemId
        this.quantity=init.quantity
        //Object.assign(this,init);
    }
    
    warehouseId:number;
    itemId:number;
    quantity:number;
}
