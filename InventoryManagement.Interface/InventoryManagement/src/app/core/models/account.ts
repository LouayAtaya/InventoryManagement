import { AccountType } from './account-type';

export class Account {
    id:number;
    accountCode:string;
    accountType:AccountType;
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
}
