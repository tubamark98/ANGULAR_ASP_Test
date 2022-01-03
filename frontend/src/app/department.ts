export class Department {
    public active : boolean;
    public name : string;
    public id : number;
    public abreviation : string;

    constructor(Name : string, Active : boolean, Abreviation : string){
        this.active = Active;
        this.name = Name;
        this.abreviation = Abreviation;
        this.id = 0;
    }
}
