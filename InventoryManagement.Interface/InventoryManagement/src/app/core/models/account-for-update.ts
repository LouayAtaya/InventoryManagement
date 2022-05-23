import { AccountType } from ".";

export class AccountForUpdate {
    constructor(init?: Partial<AccountForUpdate>){
        this.id=init.id
        this.accountCode=init.accountCode;
        this.accountType=init.accountType;
        this.amount=init.amount;
        this.name=init.name;
        this.description=init.description;
        this.isActive=init.isActive;
    }
    id:number;
    accountCode:string;
    accountType:AccountType;
    amount:number;
    name:string;
    description:string;
    isActive:boolean
}