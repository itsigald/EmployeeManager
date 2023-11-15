import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, Subscription} from "rxjs";
import IEmployee from "../code/emplyee.interface";

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http: HttpClient) {
  }

  getEmployees(): Observable<IEmployee[]> {
    // @ts-ignore
    return this.http.get('/api/employees');
  }

  // @ts-ignore
  getEmployee(id: string | null): Observable<IEmployee> {
    if (id) {
      // @ts-ignore
      return this.http.get(`/api/employees/${id}`);
    }
  }

  // @ts-ignore
  getEmployeeView(id: string | null): Observable<IEmployee> {
    if (id) {
      // @ts-ignore
      return this.http.get(`/api/employees/view/${id}`);
    }
  }


  addEmployee(employee: IEmployee) {
    return this.http.post(`/api/employees`, employee);
  }

  updateEmployee(id:number, employee: IEmployee) {
    return this.http.put(`/api/employees/${id}`, employee);
  }

  // @ts-ignore
  addOrUpdateEmployee(employee: IEmployee) {
    if(employee.id) {
      return this.updateEmployee(employee.id, employee)
    }
    return this.addEmployee(employee)
  }
}
