export class Department {
    public Active : boolean;
    public Name : string;
    public Id : number;
    public Abreviation : string;

    constructor(Name : string, Active : boolean, Abreviation : string){
        this.Active = Active;
        this.Name = Name;
        this.Abreviation = Abreviation;
        this.Id = 0;
    }
}
