import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValidateService {

  constructor() { }

  validateRequired(data: string): boolean {
    if(!data) {
      return false;
    }
    if(data.trim() === '') {
      return false;
    }
    return true;
  } 
}
