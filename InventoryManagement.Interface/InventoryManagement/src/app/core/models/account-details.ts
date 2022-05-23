export class AccountDetails {
    id:number;
    accountCode:string;
    accountType:string;
    amount:number;
    name:string;
    description:string;
    isActive:boolean
    createdAt:Date;
    createdBy:string;
    updatedAt:Date;
    updatedBy:string;
    deActivatedAt:Date;
    deActivatedBy:string;
    saleOrders:[];
}