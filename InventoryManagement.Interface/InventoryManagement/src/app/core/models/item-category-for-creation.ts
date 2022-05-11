export class ItemCategoryForCreation {
    name:string;
    description:string;
    image:string;
    isActive:boolean=true;
    parentCategoryId:number;
    childCategories:ItemCategoryForCreation[];
}
