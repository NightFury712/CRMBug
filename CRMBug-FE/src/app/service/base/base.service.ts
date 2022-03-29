import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIConfig } from 'src/app/api/config';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  controller: string = "";
  constructor(
    protected http: HttpClient
  ) {
    this.controller = `${APIConfig.development}/api/v1`
  }

  getDatas(): Observable<any> {
    return this.http.get<any>(this.controller);
  }

  getDictionary(): Observable<any> {
    const url = `${this.controller}/Dictionary`;
    return this.http.get<any>(url);
  }
}
