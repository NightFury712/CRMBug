import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { PopupInviteMemberComponent } from './../popup/popup-invite-member/popup-invite-member.component';
import { ConfigDialog } from 'src/app/modules/config-dialog';
import { MatDialog } from '@angular/material/dialog';
import { DataService } from './../../service/data/data.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.scss']
})
export class ProjectComponent implements OnInit {
  typeControl = TypeControl;
  projectName: string = '';

  projectCode: string = '';


  constructor(
    private router: ActivatedRoute,
    private dataSV: DataService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.dataSV.project.subscribe((project: any) => {
      this.projectName = project.ProjectName;
      this.projectCode = project.ProjectCode
    })
  }

  inviteUser(e: any) {
    const config = new ConfigDialog('600px');
    config.position = {
      top: '100px'
    }
    this.dialog.open(PopupInviteMemberComponent, config);
  }
}
