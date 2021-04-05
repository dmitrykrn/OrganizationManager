import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../_model/Person';
import { Report } from '../_model/Report';
import { Task } from '../_model/Task';
import { BaseService } from './BaseService';

@Injectable({
  providedIn: 'root'
})
export class TaskService extends BaseService  {

  constructor(private http: HttpClient) {
    super();
  }

  public saveTask(text: string, dueDate: string, ownerId: number): Observable<Task> {
    var task = {
      text,
      dueDate,
      ownerId,
    } as Task;

    const url = this.getUrl('api/task');
    return this.http.post<Task>(url, task);
  }
}
