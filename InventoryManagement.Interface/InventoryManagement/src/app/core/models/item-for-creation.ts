import { WarehouseItemForCreation } from './warehouse-item-for-creation';
import { ItemImageForCreation } from './item-image-for-creation';
import { ItemType } from './enums/item-type';
import { newArray } from '@angular/compiler/src/util';
export class ItemForCreation {
    constructor(init?: Partial<ItemForCreation>){
        this.code=init.code;
        this.name=init.name;
        this.description=init.description
        this.inroduction=init.inroduction
        this.price=init.price
        this.totalQuantity=init.totalQuantity
        this.itemType=init.itemType
        this.itemCategoryId=init.itemCategoryId
        this.isActive=init.isActive
        this.filesOfImages=init.filesOfImages
        init.itemImages.forEach(itemImage => {
            this.itemImages.push(new ItemImageForCreation(itemImage))
        });

        init.warehouseItems.forEach(warehouseItem=> {
            this.warehouseItems.push(new WarehouseItemForCreation(warehouseItem))
        });

        //Object.assign(this,init)
        //Object.assign(this.itemImages,init.itemImages)

    }

    code:string;
    name:string;
    description:string;
    inroduction:string;
    price:number;
    totalQuantity:number;
    itemType:ItemType; 
    itemCategoryId:number;
    isActive:boolean;
    warehouseItems: WarehouseItemForCreation[]=[];
    itemImages: ItemImageForCreation[]=[];
    filesOfImages:File[];
}