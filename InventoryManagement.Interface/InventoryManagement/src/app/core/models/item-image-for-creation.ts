export class ItemImageForCreation {
    constructor(init?: Partial<ItemImageForCreation>)
    {
        this.name=init.name
        this.description=init.description
        this.url=init.description
        //Object.assign(this,init);
    }
    name:string;
    description:string;
    url:string;
}
