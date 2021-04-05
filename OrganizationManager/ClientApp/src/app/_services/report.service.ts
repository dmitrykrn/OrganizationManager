import { HttpClient, HttpHeaders } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from '../../main';
import { Person } from '../_model/Person';
import { Report } from '../_model/Report';
import { BaseService } from './BaseService';

@Injectable({
  providedIn: 'root'
})
export class ReportService extends BaseService  {

  constructor(private http: HttpClient) {
    super();
  }

  public saveReport(text: string, ownerId: number): Observable<Report> {
    const report = {
      text,
      ownerId
    } as Report;

    const url = this.getUrl('api/report');
    return this.http.post<Report>(url, report);
  }
}
