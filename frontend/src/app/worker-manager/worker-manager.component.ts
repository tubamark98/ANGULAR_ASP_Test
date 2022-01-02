import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Worker } from '../worker';

@Component({
  selector: 'app-worker-manager',
  templateUrl: './worker-manager.component.html',
  styleUrls: ['./worker-manager.component.css']
})
export class WorkerManagerComponent implements OnInit {

  public workerCollection : Array<Worker> = new Array<Worker>();
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
      .subscribe(t => this.workerCollection = t);
  }

  erase() {
    this.actualWorker = new Worker(false,'', '','','','');
  }

  deleteWorker(id: number){
    this.http.delete('https://localhost:44343/DeleteWorker')
      .subscribe(t => console.log(t));
  }
  updateWorker(id:number){

  }
}
