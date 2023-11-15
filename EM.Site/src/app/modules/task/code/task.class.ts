import ITask from "./task.interface";

export default class Task {
  id: number | null;
  text: string;
  dueDate: Date | null;
  assignDate: Date | null;
  employeeId: number | null;
  constructor(task: ITask | undefined) {
    this.id = task && task.id || null;
    this.text = task && task.text || "";
    this.dueDate = task && task.dueDate || null;
    this.assignDate = task && task.assignDate || null;
    this.employeeId = task && task.employeeId || null;
  }
}
