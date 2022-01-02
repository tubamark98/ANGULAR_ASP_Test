import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Worker } from '../worker';
import { Department } from '../department';

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
    this.actualWorker = new Worker(false,'', '','','','');
    this.http = http;
  }

  ngOnInit(): void {
    this.sync();
  }

  saveWorker(){
    if (this.actualWorker.id == 0){
      console.log(this.actualWorker);
      this.http.post('https://localhost:44343/CreateWorker', this.actualWorker)
        .subscribe(t => console.log(t));
    }
    else{
      this.http.put('https://localhost:44343/UpdateWorker', this.actualWorker)
        .subscribe(t => console.log(t));
    }
  }

  sync(){
    this.workerCollection = new Array<Worker>();
    this.http.get<Array<Worker>>('https://localhost:44343/GetAllWorkers')
      .subscribe(t => {this.workerCollection = t; this.http.get<Array<Department>>('https://localhost:44343/GetAllDepartments')
      .subscribe(t => {this.departmentCollection = t ; this.updateWorkerStats()})});
  }

  erase() {
    this.actualWorker = new Worker(false,'', '','','','');
  }

  deleteWorker(id: number){
    this.http.delete('https://localhost:44343/DeleteWorker/'+id , )
      .subscribe(t => console.log(t));
  }
  updateWorker(id:number){

  }

  updateWorkerStats(){
    this.workerCollection.forEach(element => {
      element.departmentName = this.departmentCollection.filter(t => t.id == element.departmentId)[0].name
      element.abreviation = this.departmentCollection.filter(t => t.id == element.departmentId)[0].abreviation
    });
  }
}
