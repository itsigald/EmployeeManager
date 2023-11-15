import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {EmployeesComponent} from "./components/employee-list/employees.component";
import {EmployeeEditorComponent} from "./components/employee-editor/employee-editor.component";
import {EmployeeViewComponent} from "./components/employee-view/employee-view.component";

const routes: Routes = [
  {path: 'employees', component: EmployeesComponent},
  {path: 'employees/view/:id', component: EmployeeViewComponent},
  {path: 'employees/add', component: EmployeeEditorComponent},
  {path: 'employees/edit/:id', component: EmployeeEditorComponent},
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class EmployeeRoutingModule {
}
