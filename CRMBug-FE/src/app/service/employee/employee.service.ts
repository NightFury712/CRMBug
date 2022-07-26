import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../base/base.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService {

  constructor(
    http: HttpClient
  ) { 
    super(http);
    this.controller = `${this.controller}/Employee`
  }

  getEmployeeByProjectID(projectID: number, isInProject: boolean): Observable<any> {
    return this.http.get<any>(`${this.controller}/GetEmployeeByProjectID/${projectID}/${isInProject}`, {headers: this.headers});
  }

  register(data: any):  Observable<any> {
    return this.http.post<any>(`${this.controller}/register`,data , {headers: this.headers});
  }
}
