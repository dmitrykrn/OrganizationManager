import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from '../../_model/Person';
import { PersonList } from '../../_model/PersonList';
import { EmployeesService } from '../../_services/employees.service';

@Component({
    selector: 'app-employees',
    templateUrl: './employees.component.html',
    styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  public personList: PersonList;

  constructor(
    private employeesService: EmployeesService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.fetchEmployees();
  }

  fetchEmployees() {
    this.employeesService.getEmployees().subscribe(
      (personList: PersonList) => {
        this.personList = personList;
      }
    );
  }

  viewDetails(personId: number) {
    this.router.navigateByUrl("/employee-details/" + personId);
  }
}
