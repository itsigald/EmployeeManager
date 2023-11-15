import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {DepartmentsService} from "../../services/departments.service";
import IDepartment from "../../code/department.interface";
import Department from "../../code/department.class";

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html'
})
export class DepartmentListComponent implements OnInit {

  // @ts-ignore
  model: Department = new Department();
  departments: IDepartment[] = []

  constructor(private route: ActivatedRoute, private departmentsService: DepartmentsService) { }

  onSubmit(): void {
    console.log(this.model)
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.departmentsService.getDepartment(id).subscribe((data: any) => this.model = data);
    }
    this.departmentsService.getDepartments().subscribe((data: any) => this.departments = data);
  }
}
