import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Department } from '../department';

@Component({
  selector: 'app-department-manager',
  templateUrl: './department-manager.component.html',
  styleUrls: ['./department-manager.component.css']
})
export class DepartmentManagerComponent implements OnInit {

  public departmentCollection: Array<Department> = new Array<Department>();
  public actualDepartment : Department;
  
  private http : HttpClient;

  constructor(http : HttpClient) {
    this.actualDepartment = new Department('', false,'');
    this.http = http;
  }

  ngOnInit(): void {
    this.sync();
  }

  sync(){
    this.departmentCollection = new Array<Department>();
    this.http.get<Array<Department>>('https://localhost:44343/GetAllDepartments')
      .subscribe(t => {this.departmentCollection = t });
  }

  deleteDepart(id: number){
    this.http.delete('https://localhost:44343/DeleteDepartment/'+ id)
      .subscribe(t => this.sync());
  }

  updateDepart(id:number){
    let departToUpdate = this.departmentCollection.filter(t => t.id == id)[0];
    this.actualDepartment.id = departToUpdate.id;
    this.actualDepartment.name = departToUpdate.name;
    this.actualDepartment.abreviation = departToUpdate.abreviation;
    this.actualDepartment.active = departToUpdate.active;
  }

  erase() {
    this.actualDepartment = new Department('', false,'');
  }

  saveDepart(){
    if (this.actualDepartment.id == 0){ //create
      this.http.post('https://localhost:44343/CreateDepartment', this.actualDepartment)
        .subscribe(t => this.sync());
    }
    else{                         //update
      this.http.put('https://localhost:44343/UpdateDepartment', this.actualDepartment)
        .subscribe(t => this.sync());
    }
  }
}
