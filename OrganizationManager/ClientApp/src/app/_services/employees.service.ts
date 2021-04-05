import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { getBaseUrl } from '../../main';
import { Person } from '../_model/Person';
import { PersonDetails } from '../_model/PersonDetails';
import { PersonList } from '../_model/PersonList';
import { BaseService } from './BaseService';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  public getEmployees(): Observable<PersonList> {
    const url = this.getUrl('api/employees');
    return this.http.get<PersonList>(url);
  }

  public getEmployee(id: string): Observable<PersonDetails> {
    var url = this.getUrl('api/employees/' + id);
    return this.http.get<PersonDetails>(url);
  }
}
