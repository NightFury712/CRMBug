import { BaseService } from './../base/base.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class IssueService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
    this.controller = `${this.controller}/Issue`
  }

  getIssues(): Observable<any> {
    return this.http.get<any>(this.controller);
  }

  addIssue(issue: any) {
    return this.http.post<any>(this.controller, issue);
  }

  delete(issueID: number) {
    return this.http.delete<any>(`${this.controller}/${issueID}`);
  }
}
