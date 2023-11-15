import {Component, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import IEmployee from "../../employee/code/emplyee.interface";
import {ReportsService} from "../../report/services/reports.service";
import {TasksService} from "../services/tasks.service";

@Component({
  selector: 'assign-task-modal',
  //standalone: true,
  template: `
    <div class="modal-header">
      <h4 class="modal-title" id="modal-assign-title">Assign Task</h4>
      <button type="button" class="btn-close" aria-label="Close" (click)="activeModal.dismiss('Cross click')"></button>
    </div>
    <div class="modal-body">
      <form>
        <div class="mb-3">
          <label for="task-text">Text</label>
          <div class="input-group">
            <textarea id="task-text" class="form-control" rows="4" cols="50" [(ngModel)]="text"
                      [ngModelOptions]="{standalone: true}"></textarea>
          </div>
        </div>
        <div class="mb-3">
          <label for="dueDate">Due Date</label>
          <div class="input-group">
            <input
              id="dueDate"
              class="form-control"
              placeholder="yyyy-mm-dd"
              name="dp"
              ngbDatepicker
              #dp="ngbDatepicker"
              [(ngModel)]="dueDate"
            />
            <button class="btn btn-outline-secondary bi bi-calendar3" (click)="dp.toggle()" type="button"></button>
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


export class AssignTaskModalComponent {
  employee!: IEmployee;
  text!: string;
  dueDate!: any

  constructor(public activeModal: NgbActiveModal, private tasksService: TasksService) {
  }

  save() {
    const {year, month, day}  = this.dueDate;

    this.tasksService.assignTask({
      text: this.text,
      dueDate: new Date(year, month, day),
      employeeId: this.employee.id
    }).subscribe(() => this.activeModal.close())
  }
}
