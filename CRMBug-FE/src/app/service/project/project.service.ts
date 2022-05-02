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
}
