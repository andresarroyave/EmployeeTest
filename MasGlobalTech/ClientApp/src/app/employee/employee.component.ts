import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'mg-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  public employeeId: number;
  public employees: Employee[];
  public errorMessage: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {
  }

  public getEmployees(): void {
    this.errorMessage = '';

    if (this.employeeId && isNaN(this.employeeId)) {
      this.errorMessage = `The employee's id is not a valid number`;
      return;
    }
    
    if (this.employeeId) {
      this.http.get<Employee>(`${this.baseUrl}api/Employee/${this.employeeId}`)
        .subscribe(result => {
          this.employees = [result];
        }, error => {
            this.employees = null;
            console.error(error);
            if (error.status === 404) {
              this.errorMessage = "No employee was found with the specified id: " + this.employeeId;
            }
        });
    } else {
      this.http.get<Employee[]>(`${this.baseUrl}api/Employee`)
        .subscribe(result => {
          this.employees = result;
        }, error => console.error(error));
    }
  }
}
