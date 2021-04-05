import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { getBaseUrl } from '../../main';
import { Person } from '../_model/Person';
import { PersonDetails } from '../_model/PersonDetails';
import { PersonList } from '../_model/PersonList';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = getBaseUrl();
  }

  public getEmployees(): Observable<PersonList> {
    const url = this.getUrl('api/employees');
    return this.http.get<PersonList>(url);
  }

  public getEmployee(id: string): Observable<PersonDetails> {
    var url = this.getUrl('api/employees/' + id);
    return this.http.get<PersonDetails>(url);
  }

  private getUrl(url: string) {
    return this.baseUrl + url;
  }
}

    //var personDetails = new Observable((subscriber: Subscriber<PersonDetails>) => {
    //  const personDetails = {
    //    person: {
    //      firstName: 'John',
    //      lastName: 'Johnson',
    //      position: 'Group Lead',
    //      id: 1,
    //    },
    //    manager: {
    //      firstName: 'James',
    //      lastName: 'Smith',
    //    },
    //    picture: 'flag.png',
    //    tasks: [
    //      {
    //        text: "Task text is very importand to do.",
    //        dueDate: "30/03/2021"
    //      },
    //      {
    //        text: "Other stupid task text.",
    //        dueDate: "31/03/2021"
    //      },
    //    ],
    //    subordinates: [
    //      {
    //        id: 3,
    //        firstName: 'Robert',
    //        lastName: 'Williams',
    //        position: 'Team Lead'
    //      },
    //      {
    //        id: 4,
    //        firstName: 'Patricia',
    //        lastName: 'Jones',
    //        position: 'Team Lead'
    //      },
    //    ]
    //  } as PersonDetails;
    //  subscriber.next(personDetails);
    //});

