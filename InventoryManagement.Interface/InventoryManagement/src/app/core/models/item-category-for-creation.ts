export class ItemCategoryForCreation {
    name:string;
    description:string;
    image:string;
    isActive:boolean=true;
    parentCategoryId:number;
    childCategoriess:ItemCategoryForCreation[];
}
