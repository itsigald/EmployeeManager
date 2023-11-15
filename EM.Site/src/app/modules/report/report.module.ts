import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportRoutingModule } from './report-routing.module';
import {ReportModalComponent} from "./components/report-modal.component";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations:[ReportModalComponent],
  imports: [
    CommonModule,
    ReportRoutingModule,
    FormsModule
  ]
})
export class ReportModule { }
