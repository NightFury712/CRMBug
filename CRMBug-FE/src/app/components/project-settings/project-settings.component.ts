import { EntityState } from './../../enumeration/entity-state.enum';
import { ErrorMessage, SuccessMessage } from './../../constants/constant.enum';
import { ToastService } from './../../service/toast/toast.service';
import { EmployeeService } from './../../service/employee/employee.service';
import { takeUntil } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { ProjectService } from './../../service/project/project.service';
import { BaseComponent } from 'src/app/shared/base-component';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-project-settings',
  templateUrl: './project-settings.component.html',
  styleUrls: ['./project-settings.component.scss']
})
export class ProjectSettingsComponent extends BaseComponent implements OnInit {
  typeControl = TypeControl;

  projectID: number;

  projectInfo = {
    ProjectName: '',
    ProjectCode: '',
  }

  projectMember: Array<any> = [];

  fieldDisplay: Array<any> = [
    {
      fieldName: "FullName",
      displayText: "Full Name",
      typeControl: TypeControl.Textbox
    },
    {
      fieldName: "Email",
      displayText: "Email",
      typeControl: TypeControl.Textbox
    },
    {
      fieldName: "PhoneNumber",
      displayText: "PhoneNumber",
      typeControl: TypeControl.Textbox
    },
    {
      fieldName: "RoleIDText",
      displayText: "Role",
      typeControl: TypeControl.Textbox
    },
    {
      fieldName: "CreatedDate",
      displayText: "Join on",
      typeControl: TypeControl.DateTime
    },
  ];

  tabIndex = 1;

  constructor(
    private projectSV: ProjectService,
    private activeRoute: ActivatedRoute,
    private emoloyeeSV: EmployeeService,
    private toastSV: ToastService
  ) { 
    super();
    this.projectID = this.activeRoute.snapshot.params.projectID;
  }

  ngOnInit(): void {
    this.getProjectInfo();
  }

  switchTab(e: any, index: number) {
    this.tabIndex = index;
    if(index === 1) {
      this.getProjectInfo();
    } else {
      this.getMemberInfo();
    }
  }

  getProjectInfo() {
    if(this.projectID) {
      this.projectSV.getDataByID(this.projectID)
        .pipe(takeUntil(this._onDestroySub))
        .subscribe((resp) => {
          if(resp?.Success) {
            this.projectInfo ={ 
              ...resp.Data,
              EntityState: EntityState.Edit
            };
          }
        })
    }
  }

  getMemberInfo() {
    this.emoloyeeSV.getEmployeeByProjectID(this.projectID, true)
      .pipe(takeUntil(this._onDestroySub))
      .subscribe((resp) => {
        if(resp?.Success) {
          this.projectMember = resp.Data;
        }
      })
  }

  saveData(e: any) {
    this.projectSV.saveData(this.projectInfo)
    .pipe(takeUntil(this._onDestroySub))
    .subscribe((resp) => {
      if(resp?.Success) {
        this.toastSV.showSuccess(SuccessMessage.UpdateProject);
      } else {
        this.toastSV.showError(ErrorMessage.Exception);
      }
    })
  }
}

