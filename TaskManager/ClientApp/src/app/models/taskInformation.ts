export interface taskInformation{
  taskId: number,
  createdDate: Date,
  requiredBy: Date,
  taskDescription: string,
  taskStatus: number,
  taskStatusName: string,
  taskType: number,
  taskTypeName: string,
  assignedUserName: string,
  assignedTo : number,
  nextActionDate: Date,
  commentText: string,
  commentTypeName: string

}
