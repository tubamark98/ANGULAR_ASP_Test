import { Worker } from "./worker";

export class WorkerDTO {
    public active : boolean;
    public name : string;
    public assignment : string;
    public phoneNumber : string;
    public userName : string;
    public password : string;
    public supervisor : string;
    public id : number;
    public departmentId : number;

    constructor(worker: Worker) {
            this.active = worker.active;
            this.name = worker.name;
            this.phoneNumber = worker.phoneNumber;
            this.userName = worker.userName;
            this.password = worker.password;
            this.supervisor = worker.supervisor;
            this.id = worker.id;
            this.departmentId = worker.departmentId;
            this.assignment = worker.assignment;
    }
}
