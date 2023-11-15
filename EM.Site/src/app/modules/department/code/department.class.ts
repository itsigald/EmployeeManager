import IEmployee from "../../employee/code/emplyee.interface";
import IDepartment from "./department.interface";

export default class Department {
  id: number | null;
  name: string | undefined;
  managerId: number | null;
  managerName: string | undefined;
  constructor(department: IDepartment | undefined) {
    this.id = department && department.id || null;
    this.name = department && department.name || "";
    this.managerId = department && department.managerId || null;
    this.managerName = department && department.managerName || "';"
  }
}
