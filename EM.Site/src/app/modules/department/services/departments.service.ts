import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, Subscription} from "rxjs";
import IDepartment from "../code/department.interface";

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private http: HttpClient) {
  }

  getDepartments(): Observable<IDepartment[]> {
    // @ts-ignore
    return this.http.get('/api/departments');
  }

  // @ts-ignore
  getDepartment(id: string | null): Observable<IDepartment> {
    if (id) {
      // @ts-ignore
      return this.http.get(`/api/departments/${id}`);
    }
  }
}
