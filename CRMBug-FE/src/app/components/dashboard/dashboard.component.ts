import { DataService } from './../../service/data/data.service';
import { ProjectService } from 'src/app/service/project/project.service';
import { PopupAddProjectComponent } from './../popup/popup-add-project/popup-add-project.component';
import { MatDialog } from '@angular/material/dialog';
import { TypeControl } from './../../enumeration/type-control.enum';
import { Component, OnInit } from '@angular/core';
import { ConfigDialog } from 'src/app/modules/config-dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  typeControl = TypeControl;

  projects: any;

  constructor(
    private dialog: MatDialog,
    private projectSV: ProjectService,
    private router: Router,
    private dataSV: DataService
  ) { }

  ngOnInit(): void {
    this.projectSV.getDatas().subscribe((resp) => {
      if(resp && resp.Success && resp.Data) {
        this.projects = resp.Data;
      }
    })
  }

  addProject() {
    const config = new ConfigDialog('800px');
    config.position = {
      top: '100px'
    }
    const dialogRef = this.dialog.open(PopupAddProjectComponent, config);
  }

  openProject(project: any) {
    this.router.navigate([`/project/home/${project.ID}`]);
    this.dataSV.project.next(project);
  }
}
