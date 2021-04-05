import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { AlertType, AlertService, Alert } from '../../_services/alert.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit, OnDestroy {
  @Input() delay = 2000;
  alert: Alert;
  alertStream: Subscription;

  constructor(private alertService: AlertService) {
    this.alertStream = this.alertService.alertEvent$.subscribe((alert) => {
      this.alert = alert;
      const timeout = setTimeout(() => {
        clearTimeout(timeout);
        this.alert = null;
      }, this.delay);
    });
  }

  public get class(): string {
    if (this.alert.type === AlertType.success) {
      return 'alert alert-success';
    }
    else if (this.alert.type === AlertType.warning) {
      return 'alert alert-warning';
    }
    else if (this.alert.type === AlertType.danger) {
      return 'alert alert-danger';
    }
  }

  public get header(): string {
    if (this.alert.type === AlertType.success) {
      return 'Well done';
    }
    else if (this.alert.type === AlertType.warning) {
      return 'Warning';
    }
    else if (this.alert.type === AlertType.danger) {
      return 'Error';
    }
  }

  ngOnDestroy(): void {
    if (this.alertStream) {
      this.alertStream.unsubscribe();
    }
  }

  ngOnInit() {}
}
