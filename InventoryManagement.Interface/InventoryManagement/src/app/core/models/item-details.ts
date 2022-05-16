import { ItemType } from "./item-type";
import { WarehouseItem } from './warehouse-item';
import { ItemImage } from './item-image';
import { itemTypeList } from "./item-types-list";

export class ItemDetails {
    id:number;
    code:string;
    name:string;
    description:string;
    inroduction:string;
    price:number;
    totalQuantity:number;
    itemType:ItemType;
    itemTypeName:string;
    itemCategoryId:number;
    itemCategoryName:string;
    warehouseItems: WarehouseItem[];
    itemImages:ItemImage[]=[];
    
    isActive:boolean;
    createdAt:Date;
    createdBy: number;
    updatedAt:Date;
    updatedBy: number;
    deActivatedAt:Date;
    deActivatedBy: number;
    filesOfImages:File[]=[];
    
    
}

