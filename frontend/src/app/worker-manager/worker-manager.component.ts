import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Worker } from '../worker';
import { Department } from '../department';
import { WorkerDTO } from '../worker-dto';


@Component({
  selector: 'app-worker-manager',
  templateUrl: './worker-manager.component.html',
  styleUrls: ['./worker-manager.component.css']
})
export class WorkerManagerComponent implements OnInit {

  public workerCollection : Array<Worker> = new Array<Worker>();
  public departmentCollection: Array<Department> = new Array<Department>();
  public actualWorker : Worker;
  
  private http : HttpClient;

  constructor(http : HttpClient) {
    this.actualWorker = new Worker(false,'', '','','','','');
    this.http = http;
  }

  ngOnInit(): void {
    this.sync();
  }

  saveWorker(){
    const data = new WorkerDTO(this.actualWorker);

    if (this.actualWorker.id == 0){ //create
      console.log(data);
      this.http.post('https://localhost:44343/CreateWorker', data)
        .subscribe(t => this.sync());
    }
    else{                         //update
      this.http.put('https://localhost:44343/UpdateWorker', data)
        .subscribe(t => this.sync());
    }
  }

  sync(){
    this.workerCollection = new Array<Worker>();
    this.http.get<Array<Worker>>('https://localhost:44343/GetAllWorkers')
      .subscribe(t => {this.workerCollection = t; this.http.get<Array<Department>>('https://localhost:44343/GetAllDepartments')
      .subscribe(t => {this.departmentCollection = t ; this.updateWorkerStats()})});
  }

  erase() {
    this.actualWorker = new Worker(false,'', '','','','','');
  }

  deleteWorker(id: number){
    this.http.delete('https://localhost:44343/DeleteWorker/'+id , )
      .subscribe(t => this.sync());
  }
  updateWorker(id:number){

  }
  onSelectWorker(worker:Worker){
    this.actualWorker.supervisor = worker.name;
  }

  onSelectDepart(depart:Department){
    this.actualWorker.departmentId = depart.id;
  }

  updateWorkerStats(){
    this.workerCollection.forEach(element => {
      element.departmentName = this.departmentCollection.filter(t => t.id == element.departmentId)[0].name
      element.abreviation = this.departmentCollection.filter(t => t.id == element.departmentId)[0].abreviation
    });
  }
}
