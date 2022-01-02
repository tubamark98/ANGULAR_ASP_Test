export class Worker {
    public active : boolean;
    public name : string;
    public phoneNumber : string;
    public userName : string;
    public password : string;
    public supervisor : string;
    public id : number;
    public departmentName : string;
    public abreviation : string;
    public departmentId : number;

    constructor(active : boolean, name : string, 
        phoneNumber : string, userName : string, password : string, supervisor : string){
        this.active = active;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.userName = userName;
        this.password = password;
        this.supervisor = supervisor;
        this.id = 0;
        this.departmentId = 0;
        this.abreviation = '';
        this.departmentName = '';
    }
}
