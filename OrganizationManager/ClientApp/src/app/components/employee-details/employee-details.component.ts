import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { getBaseUrl } from '../../../main';
import { PersonDetails } from '../../_model/PersonDetails';
import { EmployeesService } from '../../_services/employees.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  public personDetails: PersonDetails;
  public showReportDialog: boolean;
  public showTaskDialog: boolean;
  public subordinateId: number;

  constructor(
    private route: ActivatedRoute,
    private service: EmployeesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.fetchEmployee();
    this.showReportDialog = false;
  }

  fetchEmployee() {
    const id = this.route.snapshot.paramMap.get('id');
    this.service.getEmployee(id).subscribe(result => {
      this.personDetails = result;
    });
  }

  get pictureUrl(): string {
    const url = getBaseUrl().concat('api/image/', this.personDetails.person.picture);
    return url;
  }

  createReport() {
    this.showReportDialog = true;
  }

  createTask(id: number) {
    this.showTaskDialog = true;
    this.subordinateId = id;
  }

  get showManager() {
    return this.personDetails.manager ? true : false;
  }
    
  get showTasks() {
    return this.personDetails.tasks.length > 0 ? true : false;
  }

  get showSubordinates() {
    return this.personDetails.subordinates.length > 0 ? true : false;
  }

  get showReportList() {
    return this.personDetails.reports.length > 0 ? true : false;
  }

  subordinate(id: number) {
    const person =
      this.personDetails
        .subordinates
        .find(person => person.id === id);

    return `${person.firstName} ${person.lastName} - ${person.position}`;
  }
}


