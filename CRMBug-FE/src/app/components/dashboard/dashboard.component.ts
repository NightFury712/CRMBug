import { BaseProjectComponent } from './../../base/base-project/base-project.component';
import { AppServerResponse } from './../../service/base/base.service';
import { takeUntil } from 'rxjs/operators';
import { BaseComponent } from 'src/app/shared/base-component';
import { PopupConfirmComponent } from './../popup/popup-confirm/popup-confirm.component';
import { NotificationService } from './../../service/notification/notification.service';
import { DataService } from './../../service/data/data.service';
import { ProjectService } from 'src/app/service/project/project.service';
import { PopupAddProjectComponent } from './../popup/popup-add-project/popup-add-project.component';
import { MatDialog } from '@angular/material/dialog';
import { TypeControl } from './../../enumeration/type-control.enum';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ConfigDialog } from 'src/app/modules/config-dialog';
import { Router } from '@angular/router';
import { Addition } from 'src/app/enumeration/addition.enum';
import { ParamGrid } from 'src/app/models/param-grid.model';
import { Operator } from 'src/app/enumeration/operator.enum';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends BaseComponent implements OnInit {
  typeControl = TypeControl;

  projects: any;

  configPaging: ParamGrid = {
    Filters: [
      {
        FieldName: 'EmployeeID',
        Value: null,
        Addition: Addition.None,
        IsFormula: false,
        Operator: Operator.None,
      },
      {
        FieldName: 'ProjectCode',
        Value: null,
        Addition: Addition.And,
        IsFormula: true,
        Operator: Operator.Like,
      },
      {
        FieldName: 'ProjectName',
        Value: null,
        Addition: Addition.And,
        IsFormula: true,
        Operator: Operator.Like,
      },
    ],
    PageIndex: 0,
    Formula: '({0} OR {1})',
    PageSize: 20,
    Columns: btoa(
      'ID,ProjectName, ProjectCode,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate'
    ),
  };

  @ViewChild("projectComponent", {static: true, read: BaseProjectComponent})
  projectComponent?: BaseProjectComponent

  constructor(
    private dialog: MatDialog,
  ) { 
    super();
  }

  ngOnInit(): void {
  }

  addProject() {
    const config = new ConfigDialog('800px');
    config.position = {
      top: '100px'
    }
    const dialogRef = this.dialog.open(PopupAddProjectComponent, config);
    dialogRef.afterClosed()
      .pipe(takeUntil(this._onDestroySub))
      .subscribe((resp) => {
        if(resp) {
          this.projectComponent?.getDatas();
        }
      })

  }

  searchProject(data: any) {
    this.projectComponent?.searchProject(data);
  }
}
