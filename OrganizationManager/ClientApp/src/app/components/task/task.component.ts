import { formatDate } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Task } from '../../_model/Task';
import { AlertService } from '../../_services/alert.service';
import { TaskService } from '../../_services/task.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  form: FormGroup;
  @Input() ownerId: number;
  @Input() visible: boolean;
  @Output() visibleChange: EventEmitter<boolean>;

  constructor(
    private service: TaskService,
    private alert: AlertService,
  ) {
    this.visible = false;
    this.visibleChange = new EventEmitter<boolean>()
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      text: new FormControl(null, [Validators.required]),
      date: new FormControl(null, [Validators.required]),
    });
  }

  save() {
    this.service.saveTask(
      this.form.value.text,
      this.form.value.date,
      this.ownerId
    ).subscribe(res => {
        this.alert.success('Task was successfully saved.');
        this.hideDialog();
      });
  }

  cancel() {
    this.hideDialog();
  }

  hideDialog() {
    this.form.reset();
    this.visible = false;
    this.visibleChange.emit(this.visible);
  }

  isInvalidField(name: string): boolean {
    const control = this.form.get(name);
    return control.invalid && (control.touched || control.dirty);
  }
}
