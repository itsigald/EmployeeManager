import {Component, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import {ReportsService} from "../services/reports.service";
import IReport from "../code/report.interface";

@Component({
  selector: 'assign-task-modal',
  //standalone: true,
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Report To Manager</h4>
      <button type="button" class="btn-close" aria-label="Close" (click)="activeModal.dismiss('Cross click')"></button>
    </div>
    <div class="modal-body">
      <form>
        <div class="mb-3">
          <label for="report-text">Report Text</label>
          <div class="input-group">
            <textarea id="report-text" class="form-control" rows="4" cols="50" [(ngModel)]="text"  [ngModelOptions]="{standalone: true}"></textarea>
          </div>
        </div>
      </form>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.dismiss()">Cancel</button>
      <button type="button" class="btn btn-outline-dark" (click)="save()">Save</button>
    </div>
  `,
  // imports: [
  //   FormsModule
  // ]
})
export class ReportModalComponent {
  managerId!: number;
  employeeId!: number;
  text!: string;

  model!: IReport

  constructor(public activeModal: NgbActiveModal, private reportsService: ReportsService) {}

  save() {
    this.reportsService.addReport({
      text: this.text,
      managerId: this.managerId,
      employeeId: this.employeeId
    }).subscribe(() => this.activeModal.close())
  }
}
