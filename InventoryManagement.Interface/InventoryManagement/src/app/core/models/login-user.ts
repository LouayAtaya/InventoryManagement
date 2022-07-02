
export class LoginUser {
    constructor(init?: Partial<LoginUser>){
        this.username=init.username;
        this.password=init.password;          
        
    }
    username:string;
    password:string;

}