import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { APIConfig } from 'src/app/api/config';

export interface AppServerResponse<T> {
  success: boolean,
  data: T,
  userMsg: string,
  devMsg: string
  errorCode: string
}

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

  saveData(data: any):  Observable<any> {
    return this.http.post<any>(this.controller, data);
  }

  getDictionary(): Observable<any> {
    const url = `${this.controller}/Dictionary`;
    return this.http.get<any>(url);
  }
}
