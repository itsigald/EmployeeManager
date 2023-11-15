import {AfterViewInit, Component, ElementRef, Inject, OnInit, TemplateRef, ViewChild} from '@angular/core';
import IEmployee from "../../code/emplyee.interface";
import Employee from "../../code/employee.class";
import IDepartment from "../../../department/code/department.interface";
import {ActivatedRoute} from "@angular/router";
import {EmployeesService} from "../../services/employees.service";
import {DepartmentsService} from "../../../department/services/departments.service";
import IKeyValue from "../../../../common/interfaces/IKeyValue";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AssignTaskModalComponent} from "../../../task/components/assign-task-modal.component";
import {ReportModalComponent} from "../../../report/components/report-modal.component";

@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.css']
})
export class EmployeeViewComponent implements OnInit {
  // @ts-ignore
  model: IEmployee = new Employee();
  department: IDepartment | undefined;
  submitted: boolean = false;
  currentDialog = null;

  constructor(private route: ActivatedRoute,
              private employeesService: EmployeesService,
              private departmentsService: DepartmentsService,
              @Inject('POSITIONS') public positions: IKeyValue[],
              private modalService: NgbModal) {
  }

  report() {
    const modalRef = this.modalService.open(ReportModalComponent, {size: 'lg'});
    modalRef.componentInstance.managerId = this.model.managerId;
    modalRef.componentInstance.employeeId = this.model.id
  }

  assign(reportContent: TemplateRef<ElementRef>, id: number) {
    this.modalService.open(reportContent, {ariaLabelledBy: 'modal-assign-title'}).result.then(
      (result) => {
        console.log(result)
      },
      (reason) => {
        console.log(reason)
      },
    );
  }

  assignTask(subordinate: IEmployee) {
    const modalRef = this.modalService.open(AssignTaskModalComponent, {size: 'lg'});
    modalRef.componentInstance.employee = subordinate;
  }

  onSubmit(): void {
    this.employeesService.addOrUpdateEmployee(this.model).subscribe();
    this.submitted = true;
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.employeesService.getEmployeeView(id).subscribe(data => this.model = data);
    }
    // @ts-ignore
    //this.departmentsService.getDepartments().subscribe((data) => this.departments = data);
  }
}
