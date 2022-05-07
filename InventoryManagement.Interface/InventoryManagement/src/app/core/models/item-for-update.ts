import { ItemType } from "./item-type";
import { WarehouseItemForUpdate } from './warehouse-item-for-update';
import { ItemImageForUpdate } from './item-image-for-update';

export class ItemForUpdate {
    code:string;
    name:string;
    description:string;
    inroduction:string;
    price:number;
    totalQuantity:number;
    itemType:ItemType; 
    itemCategoryId:number;
    isActive:boolean;
    warehouseItems: WarehouseItemForUpdate[];
    itemImages: ItemImageForUpdate[];
}
