import {Component, Inject, Injectable, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {EmployeesService} from "../../services/employees.service";
import IEmployee from "../../code/emplyee.interface";
import Employee from "../../code/employee.class";
import IKeyValue from "../../../../common/interfaces/IKeyValue";
import {DepartmentsService} from "../../../department/services/departments.service";
import IDepartment from "../../../department/code/department.interface";

@Component({
  selector: 'app-employee-editor',
  templateUrl: './employee-editor.component.html'
})
export class EmployeeEditorComponent implements OnInit {
  // @ts-ignore
  model: IEmployee;
  employees: IEmployee[] | undefined;
  departments: IDepartment[] = []
  submitted: boolean = false;

  constructor(private route: ActivatedRoute,
              private employeesService: EmployeesService,
              private departmentsService: DepartmentsService,
              @Inject('POSITIONS') public positions: IKeyValue[]) {
  }

  onSubmit(): void {
    this.employeesService.addOrUpdateEmployee(this.model).subscribe();
    this.submitted = true;
  }

  addAnother(): void {
    this.submitted = false;
    // @ts-ignore
    this.model = new Employee();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.employeesService.getEmployees().subscribe((employees)=> {
        // @ts-ignore
        this.model = employees.find( x => x.id == id);
        // @ts-ignore
        this.employees = employees.filter( x => x.id != id);
      });
    }
    else {
      this.employeesService.getEmployees().subscribe((employees)=> {
        // @ts-ignore
        this.model = new Employee();
        // @ts-ignore
        this.employees = employees;
      });
    }
    // @ts-ignore
    this.departmentsService.getDepartments().subscribe((data) => this.departments = data);
  }
}
