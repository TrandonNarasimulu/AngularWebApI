import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-employees',
  templateUrl: './fetch-employees.component.html',
  styleUrls: ['./fetch-employees.component.css']
})

export class FetchEmployeeDataComponent {

  public employees: EmployeeDetails[];
  public httpClient: HttpClient;
  public baseUrl: string;
  public isVisible: boolean = false;
  public newEmployeeDetails: NewEmployeeDetails;
  public isDisabled = false;

  public newEmployee: CreateEmployeeModel = {
    firstName: "",
    lastName: "",
    birthDate: null
  };

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.GetAllEmployeeData();
  }

  public GetAllEmployeeData() {
    this.httpClient.get<EmployeeDetails[]>(this.baseUrl + 'api/EmployeeManagement/GetAllEmployees').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));
  }

  public AddEmployee(employee: any) {
    employee.editable = !employee.editable;
    this.isDisabled = true;
  }

  public SaveNewEmployee(employee: any) {
    employee.editable = !employee.editable;

    if (!employee.editable) {
      this.httpClient.post<NewEmployeeDetails>(this.baseUrl + 'api/EmployeeManagement/CreateEmployee', employee).subscribe(result => {
        this.newEmployeeDetails = result;
        window.location.reload();
      }, error => console.error(error));
    }
    this.isDisabled = false;
  }

  public CancelAddingEmployee(employee: any) {
    employee.editable = !employee.editable;
    this.isDisabled = false;
  }

  public Update(employee: any) {
    employee.editable = !employee.editable;

    if (!employee.editable) {
      this.httpClient.patch<number>(this.baseUrl + 'api/EmployeeManagement/UpdateEmployeeDetails', employee).subscribe(result => {
        
      }, error => console.error(error));
    }
  }

  public Delete(employee: any) {
    if (confirm("Are you sure you want to delete employee: " + employee.firstName + " " + employee.lastName)) {
      this.httpClient.delete<number>(this.baseUrl + 'api/EmployeeManagement/DeleteEmployee/' + employee.employeeNum).subscribe(result => {
        window.location.reload();
      }, error => console.error(error));
    }
  }

  public EmployeeSearch(employeeNumber: string) {
    this.httpClient.get<EmployeeDetails>(this.baseUrl + 'api/EmployeeManagement/GetEmployeeDetails/' + employeeNumber).subscribe(result => {
      this.employees = [];
      this.employees.push(result);
    }, error => console.error(error));
  }
}

interface EmployeeDetails {
  firstName: string;
  lastName: string;
  birthDate: Date;
  employeeNum: string;
  employedDate: Date,
  terminatedDate: Date
}

interface CreateEmployeeModel {
  firstName: string;
  lastName: string;
  birthDate: Date;
}

interface NewEmployeeDetails {
  employeeNumber: string;
  employmentDate: Date
}
