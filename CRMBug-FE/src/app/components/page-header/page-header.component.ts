import { PopupUpdateUserSettingComponent } from './../popup/popup-update-user-setting/popup-update-user-setting.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { ConfigDialog } from 'src/app/modules/config-dialog';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss']
})
export class PageHeaderComponent implements OnInit {

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  updateUserSetting() {
    let config = new ConfigDialog('600px');
    config.position = {
      top: '100px'
    }
    const dialogRef = this.dialog.open(PopupUpdateUserSettingComponent, config);
  }
}
