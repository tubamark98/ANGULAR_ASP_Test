import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentManagerComponent } from './department-manager/department-manager.component';
import { WorkerManagerComponent } from './worker-manager/worker-manager.component';

const routes: Routes = [
  {path : 'worker', component: WorkerManagerComponent},
  {path : 'department', component: DepartmentManagerComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
