import { BaseService } from './../base/base.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService extends BaseService {

  constructor(http: HttpClient) {
    super(http);
    this.controller = `${this.controller}/Task`
  }

  getFormData(projectID: number, masterID: number, formModeState: number): Observable<any> {
    return this.http.get<any>(`${this.controller}/FormData/${projectID}/${masterID}/${formModeState}`, {headers: this.headers});
  }
}
