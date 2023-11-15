import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DepartmentListComponent} from "./components/department-list/department-list.component";

const routes: Routes = [
  {path: 'departments', component: DepartmentListComponent},
  // {path: 'departments/edit/:id', component: DepartmentListComponent},
  // {path: 'departments/add', component: DepartmentListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentRoutingModule {
}
