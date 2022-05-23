import { DataService } from './../../../service/data/data.service';
import { EmployeeService } from './../../../service/employee/employee.service';
import { TypeControl } from './../../../enumeration/type-control.enum';
import { ConfigDialog } from './../../../modules/config-dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-popup-update-user-setting',
  templateUrl: './popup-update-user-setting.component.html',
  styleUrls: ['./popup-update-user-setting.component.scss']
})
export class PopupUpdateUserSettingComponent implements OnInit {
  typeControl = TypeControl;

  userData: any = {
    FirstName: '',
    LastName: '',
    Email: '',
    Phone: ''
  };

  constructor(
    public dialogRef: MatDialogRef<PopupUpdateUserSettingComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dataSV: DataService,
    private employeeSV: EmployeeService
  ) { }

  ngOnInit(): void {
    let userID = 0;
    this.dataSV.user.subscribe((user: any) => {
      userID = user.id;
    })
    this.employeeSV
      .getDataByID(userID)
      .subscribe((resp) => {
        if(resp && resp.Success && resp.Data) {
          this.userData = resp.Data;
        }
    })
  }

  close() {
    this.dialogRef.close();
  }

  saveData() {

  }
}
