import { ValidateService } from './../../service/validation/validate.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ValidateMessage } from 'src/app/enumeration/enumeration.enum';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  validateMessage: any = ValidateMessage;

  dataSave: any = {
    Username: '',
    Password: '',
    Email: '',
    PhoneNumber: '',
    FirstName: '',
    LastName: ''
  }

  errorList: any = {}

  passwordReEnter = '';

  isShowErrorMessage: boolean = false;
  constructor(
    private router: Router,
    private validateSV : ValidateService
  ) { }

  ngOnInit(): void {
  }


  register(e: any) {
    let isValid = true;
    this.errorList = {};
    Object.keys(this.dataSave).forEach(fieldName => {
      debugger;
      let valid = this.validateSV.validateOption(this.dataSave[fieldName], fieldName);
      if(!valid) {
        this.errorList[fieldName] = this.validateMessage[fieldName]
      } else {
        this.errorList[fieldName] = '';
      }
      isValid = isValid && valid;
    })
    this.isShowErrorMessage = isValid;
    if(isValid) {
      
    }
    console.log(this.dataSave);
  }

  backToLogin(e: any) {
    this.router.navigate(['/login'])
  }
}
