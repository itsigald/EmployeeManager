import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import {AssignTaskModalComponent} from "./components/assign-task-modal.component";
import {FormsModule} from "@angular/forms";
import {NgbInputDatepicker} from "@ng-bootstrap/ng-bootstrap";


@NgModule({
  declarations: [AssignTaskModalComponent],
  imports: [
    CommonModule,
    TaskRoutingModule,
    FormsModule,
    NgbInputDatepicker
  ]
})
export class TaskModule { }
