import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  project = new BehaviorSubject<any>({});

  //user hiện tại
  user = new BehaviorSubject<any>(null);

  task = new BehaviorSubject<any>(null);

  loading = new BehaviorSubject<boolean>(false);
  constructor() { }
}
