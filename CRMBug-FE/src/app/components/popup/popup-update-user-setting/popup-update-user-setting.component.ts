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
    Email: '',
    Phone: ''
  };

  constructor(
    public dialogRef: MatDialogRef<PopupUpdateUserSettingComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
  }

  close() {
    this.dialogRef.close();
  }

  saveData() {

  }
}
