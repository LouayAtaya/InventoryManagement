import { ItemOperationType } from ".";

export class ItemOperation {
    id:number;
    itemId:number;
    itemName:string;
    warehouseId:number;
    warehouseName:string;
    previousQuantity:number;
    affectedQuantity:number;
    description:string;
    itemOperationType:ItemOperationType
    isActive:boolean;
    createdAt:Date;
    createdBy: number;
    updatedAt:Date;
    updatedBy: number;
    deActivatedAt:Date;
    deActivatedBy: number;
}