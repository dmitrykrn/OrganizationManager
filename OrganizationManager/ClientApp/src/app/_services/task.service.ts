import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from '../../main';
import { Person } from '../_model/Person';
import { Report } from '../_model/Report';
import { Task } from '../_model/Task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = getBaseUrl();
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

  private getUrl(url: string) {
    return this.baseUrl + url;
  }
}
