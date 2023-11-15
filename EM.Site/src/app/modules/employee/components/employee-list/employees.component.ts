import {Component, Inject, OnInit} from '@angular/core';

import IEmployee from "../../code/emplyee.interface";
import {EmployeesService} from "../../services/employees.service";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent implements OnInit {
  public employees: IEmployee[] = [];
  constructor(private  service: EmployeesService) { }

  ngOnInit(): void {
    this.service.getEmployees().subscribe(data => this.employees = data);
  }
}
