import { Injectable } from '@angular/core';
import { APIConfig } from 'src/app/api/config';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  controller: string = "";
  constructor() {
    this.controller = `${APIConfig.development}/api/v1`
  }
}
