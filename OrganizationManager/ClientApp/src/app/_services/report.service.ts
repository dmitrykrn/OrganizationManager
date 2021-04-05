import { HttpClient, HttpHeaders } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { getBaseUrl } from '../../main';
import { Person } from '../_model/Person';
import { Report } from '../_model/Report';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private baseUrl: string;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) {
    this.baseUrl = getBaseUrl();
  }

  public saveReport(text: string, ownerId: number): Observable<Report> {
    const report = {
      text,
      ownerId
    } as Report;

    const url = this.getUrl('api/report');
    return this.http.post<Report>(url, report);
  }

  private getUrl(url: string) {
    return this.baseUrl.concat(url);
  }
}
