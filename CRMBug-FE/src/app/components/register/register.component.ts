import { takeUntil, catchError } from 'rxjs/operators';
import { EmployeeService } from './../../service/employee/employee.service';
import { EntityState } from './../../enumeration/entity-state.enum';
import { ValidateService } from './../../service/validation/validate.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ValidateMessage } from 'src/app/enumeration/enumeration.enum';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  _onDestroySub: Subject<void> = new Subject<void>();
  
  validateMessage: any = ValidateMessage;

  dataSave: any = {
    Username: '',
    Password: '',
    Email: '',
    PhoneNumber: '',
    FirstName: '',
    LastName: '',
    EntityState: EntityState.Add,
  }

  errorList: any = {
    Username: '',
    Password: '',
    Email: '',
    PhoneNumber: '',
    FirstName: '',
    LastName: '',
    PasswordReEnter: '',
  }

  passwordReEnter = '';

  isShowErrorMessage: boolean = false;
  constructor(
    private router: Router,
    private validateSV : ValidateService,
    private employeeSV: EmployeeService
  ) { }

  ngOnInit(): void {
  }


  register(e: any) {
    if(this.validateRegister()) {
      this.saveData()
    }
  }

  backToLogin(e: any) {
    this.router.navigate(['/login'])
  }

  saveData() {
    const dataSave = JSON.parse(JSON.stringify(this.dataSave));
    dataSave.Password = btoa(dataSave.Password);
    this.employeeSV
      .register(dataSave)
      .pipe(takeUntil(this._onDestroySub))
      .subscribe((resp) => {
        console.log(resp);
        if(resp?.Success) {
          this.router.navigate(['/login'])
        }
      },
      error => {
        console.log(error);
      })
  }

  validateRegister(): boolean {
    let isValid = true;
    this.errorList = {};
    Object.keys(this.dataSave).forEach(fieldName => {
      let valid = this.validateSV.validateOption(this.dataSave[fieldName], fieldName);
      if(!valid) {
        this.errorList[fieldName] = this.validateMessage[fieldName]
      } else {
        this.errorList[fieldName] = '';
      }
      isValid = isValid && valid;
    })
    if(this.passwordReEnter !== this.dataSave.Password) {
      isValid = false;
      this.errorList['PasswordReEnter'] = this.validateMessage['PasswordReEnter'];
    }
    this.isShowErrorMessage = isValid;
    return isValid;
  }
}
