import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WorkerManagerComponent } from './worker-manager/worker-manager.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {MatListModule} from '@angular/material/list';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DepartmentManagerComponent } from './department-manager/department-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    WorkerManagerComponent,
    DepartmentManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatListModule,
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
