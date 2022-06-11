import { ItemOperationType } from ".";

export class ItemOperationForCreation {

    constructor(init?: Partial<ItemOperationForCreation>){
        this.itemId =init.itemId
        this.warehouseId =init.warehouseId
        this.affectedQuantity =init.affectedQuantity
        this.description =init.description
        this.itemOperationType =init.itemOperationType
        this.isActive=init.isActive
    }

    itemId:number;
    warehouseId:number;
    affectedQuantity:number;
    description:string;
    itemOperationType:ItemOperationType
    isActive:boolean;
}