import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {EmployeesComponent} from "./components/employee-list/employees.component";
import {EmployeeEditorComponent} from "./components/employee-editor/employee-editor.component";
import {EmployeesService} from "./services/employees.service";
import {EmployeeRoutingModule} from './employee-routing.module';
import {EmployeeViewComponent} from './components/employee-view/employee-view.component';
import {FormsModule} from "@angular/forms";
import {DepartmentsService} from "../department/services/departments.service";
import {NgbInputDatepicker} from "@ng-bootstrap/ng-bootstrap";
//import { ReportModalComponent } from './components/assign-task-modal/assign-task-modal.component';
//import {FlexLayoutModule} from '@angular/flex-layout';

@NgModule({
  declarations: [
    EmployeesComponent,
    EmployeeEditorComponent,
    EmployeeViewComponent,
    //ReportModalComponent
  ],
  providers: [EmployeesService, DepartmentsService],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    FormsModule,
    NgbInputDatepicker,
    // FlexLayoutModule
  ]
})
export class EmployeeModule {
}
