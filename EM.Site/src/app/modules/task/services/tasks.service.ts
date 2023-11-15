import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import IReport from "../../report/code/report.interface";
import ITask from "../code/task.interface";

@Injectable({
  providedIn: 'root'
})
export class TasksService {

  constructor(private http: HttpClient) {
  }

  assignTask(task: { dueDate: Date; employeeId: number | null; text: string }) {
    return this.http.post(`/api/tasks`, task);
  }
}
