import { ItemType } from "./item-type";
import { WarehouseItemForUpdate } from './warehouse-item-for-update';
import { ItemImageForUpdate } from './item-image-for-update';

export class ItemForUpdate {
    constructor(init?: Partial<ItemForUpdate>){
        this.id=init.id
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
            this.itemImages.push(new ItemImageForUpdate(itemImage))
        });

        init.warehouseItems.forEach(warehouseItem=> {
            this.warehouseItems.push(new WarehouseItemForUpdate(warehouseItem))
        });

        //Object.assign(this,init)
        //Object.assign(this.itemImages,init.itemImages)

    }

    id:number;
    code:string;
    name:string;
    description:string;
    inroduction:string;
    price:number;
    totalQuantity:number;
    itemType:ItemType; 
    itemCategoryId:number;
    isActive:boolean;
    warehouseItems: WarehouseItemForUpdate[]=[];
    itemImages: ItemImageForUpdate[]=[];

    filesOfImages:File[]=[];
    
}
