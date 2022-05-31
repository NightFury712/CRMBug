import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  headers: any;
  constructor(
    protected http: HttpClient
  ) {
    let accessToken = localStorage.getItem('AccessToken');
    this.controller = `${APIConfig.development}/api/v1`;
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8',
      'Authorization': "Bearer " + accessToken
    });
  }

  getDatas(): Observable<any> {
    return this.http.get<any>(this.controller, {headers: this.headers});
  }

  grid(param: any): Observable<any> {
    const url = `${this.controller}/Grid`;
    return this.http.post<any>(url,param , {headers: this.headers})
  }

  saveData(data: any):  Observable<any> {
    return this.http.post<any>(this.controller,data , {headers: this.headers});
  }

  getDictionary(): Observable<any> {
    const url = `${this.controller}/Dictionary`;
    return this.http.get<any>(url, {headers: this.headers});
  }

  getDataByID(id: number): Observable<any> {
    const url = `${this.controller}/${id}`;
    return this.http.get<any>(url, {headers: this.headers});
  }

  delete(id: number): Observable<any> {
    const url = `${this.controller}/${id}`;
    return this.http.delete<any>(url, {headers: this.headers});
  }
}
