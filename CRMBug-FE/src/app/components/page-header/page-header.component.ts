import { RecentlyViewedComponent } from './../recently-viewed/recently-viewed.component';
import { SignalrService } from './../../service/signalr/signalr.service';
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
    private router: Router,
    private signalr: SignalrService,
  ) { 
    super();
    this.dataSV.user.pipe(takeUntil(this._onDestroySub)).subscribe((user) => {
      if(user) {
        this.fullName = user.fullName;
        this.firstCharacter = user.fullName.charAt(0);
      }
    });
  }

  ngOnInit(): void {
    this.signalr.startConnection();
    this.signalr.addListener();
  }

  ngOnDestroy(): void {
    this.signalr.disconnect();
    super.ngOnDestroy();
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

  openRecentlyViewed() {
    let config = new ConfigDialog('500px', '450px');

    config.position = {
      top: '60px',
      left: '160px'
    }
    config.backdropClass = 'no-background'
    const dialogRef = this.dialog.open(RecentlyViewedComponent, config);
    dialogRef.afterClosed()
      .pipe(takeUntil(this._onDestroySub))
      .subscribe(resp => {
        if(resp) {
          this.dataSV.task.next(resp)
          this.dataSV.project.next({
            ID: resp.ProjectID,
            ProjectName: resp.ProjectName,
            ProjectCode: resp.ProjectCode
          })
          this.router.navigate([`/project/view-task/${resp.ProjectID}`])
        }
        console.log(resp);
      })
  }
}
