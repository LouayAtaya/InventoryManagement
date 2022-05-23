import { AccountType } from ".";

export class AccountForCreation {
    constructor(init?: Partial<AccountForCreation>){
        this.accountCode=init.accountCode;
        this.accountType=init.accountType;          
        this.amount=init.amount
        this.name=init.name
        this.description=init.description
        this.isActive=init.isActive
    }
    accountCode:string;
    accountType:AccountType;
    amount:number;
    name:string;
    description:string;
    isActive:boolean

}