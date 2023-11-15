import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import IReport from "../code/report.interface";

@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  constructor(private http: HttpClient) {}

  addReport(report: IReport) {
    return this.http.post(`/api/reports`, report);
  }
}
