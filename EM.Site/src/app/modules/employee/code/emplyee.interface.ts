import ITask from "../../task/code/task.interface";

export default  interface IEmployee {
  id: number | null;
  firstName: string;
  lastName: string;
  position: number | null;
  positionName: string;
  departmentId: number | null;
  departmentName: string;
  managerId: number | null;
  managerName: string;
  tasks?: ITask[] | null;
  subordinates?: IEmployee[] | null
}
