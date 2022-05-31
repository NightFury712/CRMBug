import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './../base/base.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService {

  constructor(
    http: HttpClient
  ) {
    super(http);
    this.controller = `${this.controller}/Project`;
  }

  inviteUser(param: any): Observable<any> {
    return this.http.post<any>(`${this.controller}/InviteUser`, param, {headers: this.headers});
  }
}
