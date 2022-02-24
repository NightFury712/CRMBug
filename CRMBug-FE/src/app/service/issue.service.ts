import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class IssueService {
  url: string = 'https://localhost:5001/api/v1/Issue';
  constructor(private http: HttpClient) {}

  getIssues(): Observable<any> {
    return this.http.get<any>(this.url);
  }

  addIssue(issue: any) {
    return this.http.post<any>(this.url, issue);
  }

  delete(issueID: number) {
    return this.http.delete<any>(`this.url/${issueID}`);
  }
}
