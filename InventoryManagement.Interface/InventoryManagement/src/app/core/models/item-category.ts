export class ItemCategory {
    id:number;
    name:string;
    description:string;
    image:string;
    parentCategoryId:number;
    childCategories:ItemCategory[];
    isActive:boolean;
    createdAt:Date;
    createdBy: number;
    updatedAt:Date;
    updatedBy: number;
    deActivatedAt:Date;
    deActivatedBy: number    
}
