import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { taskInformation } from '../models/taskInformation';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { taskType } from '../models/TaskType';
import { taskStatus } from '../models/taskStatus';
import { commentType } from '../models/commentType';
import { FormBuilder, FormControl } from '@angular/forms'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  visibleOnTaskCreation: boolean = false;
  added: boolean = false;
  taskInformation: Array<taskInformation> = [];
  taskType: Array<taskType> = [];
  taskStatus: Array<taskStatus> = [];
  commentType: Array<commentType> = [];
  constructor(private httpClient: HttpClient) {

  }

  ngOnInit(): void {
    console.log(this.getTasks().subscribe(response => { this.taskInformation = response }));
    this.taskType = [
      { taskTypeId: 1, taskTypeName: "User Instruction" },
      { taskTypeId: 2, taskTypeName: "Technical Info" }
    ];

    this.taskStatus = [
      { taskStatusId: 1, taskStatusName: "Not Started" },
      { taskStatusId: 2, taskStatusName: "In Progress" },
      { taskStatusId: 3, taskStatusName: "Cancelled" },
      { taskStatusId: 4, taskStatusName: "Completed" }
    ];

    this.commentType = [
      { CommentTypeId: 1, CommentTypeName: "New" },
      { CommentTypeId: 2, CommentTypeName:"Update" }
    ]
  }

  public getTasks(): Observable<taskInformation[]> {
    const url = 'https://localhost:7067/api/Tasks'
    return this.httpClient.get<taskInformation[]>(url)
  }

  public async onSubmit(taskInfo: taskInformation) {
    //let jsonObject: any = JSON.parse(taskInfo);
    //let course: taskInformation = <taskInformation>jsonObj;
    const url = 'https://localhost:7067/api/Tasks'
    const response = this.httpClient.post<taskInformation[]>(url, JSON.stringify(taskInfo));
    //await response.toPromise();
    this.visibleOnTaskCreation = false;
    this.added = true;
    //console.log(taskInfo);
  }

  createTasks() {
    this.visibleOnTaskCreation = true;
  }

  ontaskSelected(val: any) {
    console.log(val);
  }
}
