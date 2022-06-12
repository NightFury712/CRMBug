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

  validateEmail(email: string): boolean {
    const regex =  /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regex.test(email);
  }

  validateOption(value: any, fieldName: string): boolean {
    switch(fieldName) {
      case "Username":
      case "Password":
      case "FirstName":
      case "LastName":
      case "Subject":
      case "ProjectName":
      case "ProjectCode":
        return this.validateRequired(value);
      case "Email":
        return this.validateEmail(value);

      default: 
        return true;
    }
  }
}
