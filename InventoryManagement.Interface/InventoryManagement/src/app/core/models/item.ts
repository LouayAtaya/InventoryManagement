import { ItemImage } from ".";
import { ItemType } from "./enums/item-type";

export class Item {
    id:number;
    code:string;
    name:string;
    description:string;
    inroduction:string;
    minPrice:number;
    price:number;
    totalQuantity:number;
    itemType:ItemType;
    itemCategoryId:number;
    itemCategoryName:string;
    isActive:boolean;
    createdAt:Date;
    createdBy: number;
    updatedAt:Date;
    updatedBy: number;
    deActivatedAt:Date;
    deActivatedBy: number
    itemImages:ItemImage[]=[];

}
