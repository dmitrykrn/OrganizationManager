import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { AlertService } from '../_services/alert.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private router: Router,
    private alert: AlertService
  ) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          const msg = `Something went wrong, try again later. ${error.error.message}`;
          this.alert.danger(msg);
          console.log(error);
        }
        return throwError(error);
      })
    )
  }
}
