import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Person } from '../../_model/Person';
import { Report } from '../../_model/Report';
import { AlertService } from '../../_services/alert.service';
import { ReportService } from '../../_services/report.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  form: FormGroup;
  @Input() ownerId: number;
  @Input() visible: boolean;
  @Output() visibleChange: EventEmitter<boolean>;

  constructor(
    private reportSvc: ReportService,
    private alertSvc: AlertService,
  ) {
    this.visible = false;
    this.visibleChange = new EventEmitter<boolean>()
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      text: new FormControl(null, [Validators.required]),
    });
  }

  save() {
    this.reportSvc.saveReport(
      this.form.value.text,
      this.ownerId)
      .subscribe(res => {
          this.alertSvc.success("Report was successfully saved.");
          this.hideDialog();
        }
      );
  }

  cancel() {
    this.hideDialog();
  }

  hideDialog() {
    this.form.reset();
    this.visible = false;
    this.visibleChange.emit(this.visible);
  }

  isInvalid(name: string): boolean {
    const control = this.form.get(name);
    return control.invalid && (control.touched || control.dirty);
  }
}
