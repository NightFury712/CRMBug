import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class IssueService {
  url: string = '';

  constructor(private http: HttpClient) {
    this.url = `${environment.endPoint}v1/Issue`;
  }

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
