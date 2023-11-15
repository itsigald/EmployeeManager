import IEmployee from "./emplyee.interface";
import ITask from "../../task/code/task.interface";

export default class Employee implements IEmployee {
  id: number | null;
  firstName: string;
  lastName: string;
  position: number | null;
  positionName: string;
  departmentId: number | null;
  departmentName: string;
  managerId: number | null;
  managerName: string;
  tasks: ITask[] | null;
  subordinates?: IEmployee[] | null
  constructor(employee: IEmployee | undefined) {
    this.id = employee && employee.id || null;
    this.firstName = employee && employee.firstName || "";
    this.lastName = employee && employee.lastName || "";
    this.position = employee && employee.position || null;
    this.positionName = employee && employee.positionName || "";
    this.departmentId = employee && employee.departmentId || null;
    this.departmentName = employee && employee.departmentName || "";
    this.managerId = employee && employee.managerId || null;
    this.managerName = employee && employee.managerName || "";
    this.tasks = employee && employee.tasks || null;
    this.subordinates = employee && employee.subordinates || null;
  }
}
