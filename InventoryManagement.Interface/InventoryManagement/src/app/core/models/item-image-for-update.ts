export class ItemImageForUpdate {
    constructor(init?: Partial<ItemImageForUpdate>)
    {
        this.id=init.id
        this.name=init.name
        this.description=init.description
        this.url=init.description
        //Object.assign(this,init);
    }

    id:number;
    name:string;
    description:string;
    url:string;
}
