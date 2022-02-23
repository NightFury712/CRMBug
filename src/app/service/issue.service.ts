import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IssueService {
  url: string = 'https://localhost:44378/api/v1/Issue';
  constructor(private http: HttpClient) { }

  getIssues(): Observable<any> {
    return this.http.get<any>(this.url);
  }

  addIssue(issue: any) {
    return this.http.post<any>(this.url, issue);
  }
}
