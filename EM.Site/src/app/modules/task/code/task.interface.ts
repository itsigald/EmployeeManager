export default interface ITask {
  id: number | null;
  text: string;
  dueDate: Date;
  assignDate: Date;
  employeeId: number;
  status: number;
}
