import { takeUntil } from 'rxjs/operators';
import { BaseComponent } from 'src/app/shared/base-component';
import { Router } from '@angular/router';
import { DataService } from './../../service/data/data.service';
import { AuthService } from './../../service/auth/auth.service';
import { PopupUpdateUserSettingComponent } from './../popup/popup-update-user-setting/popup-update-user-setting.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { ConfigDialog } from 'src/app/modules/config-dialog';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss']
})
export class PageHeaderComponent extends BaseComponent implements OnInit {

  fullName: string = "";

  firstCharacter: string = "H";

  constructor(
    private dialog: MatDialog,
    private authSV: AuthService,
    private dataSV: DataService,
    private router: Router
  ) { 
    super();
    this.dataSV.user.pipe(takeUntil(this._onDestroySub)).subscribe((user) => {
      if(user) {
        this.fullName = user.fullName;
        this.firstCharacter = user.fullName.charAt(0);
      }
    })
  }

  ngOnInit(): void {
  }

  updateUserSetting() {
    let config = new ConfigDialog('600px');
    config.position = {
      top: '100px'
    }
    const dialogRef = this.dialog.open(PopupUpdateUserSettingComponent, config);
  }

  logout() {
    this.authSV.logout();
    this.router.navigate(["/login"])
  }
}
