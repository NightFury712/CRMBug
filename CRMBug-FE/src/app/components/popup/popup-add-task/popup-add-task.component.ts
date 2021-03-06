import { AppServerResponse } from './../../../service/base/base.service';
import { SignalrService } from './../../../service/signalr/signalr.service';
import { TaskPriority, TaskState } from './../../../enumeration/task.enum';
import { BaseComponent } from 'src/app/shared/base-component';
import { Options } from '@angular-slider/ngx-slider';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { takeUntil } from 'rxjs/operators';
import { SuccessMessage, ErrorMessage } from 'src/app/constants/constant.enum';
import { EntityState } from 'src/app/enumeration/entity-state.enum';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { DataService } from 'src/app/service/data/data.service';
import { EmployeeService } from 'src/app/service/employee/employee.service';
import { TaskService } from 'src/app/service/task/task.service';
import { ToastService } from 'src/app/service/toast/toast.service';

@Component({
  selector: 'app-popup-add-task',
  templateUrl: './popup-add-task.component.html',
  styleUrls: ['./popup-add-task.component.scss'],
})
export class PopupAddTaskComponent extends BaseComponent implements OnInit {
  //#region Properties
  sliderOptions: Options = {
    floor: 0,
    ceil: 100,
  };

  typeControl = TypeControl;

  title: string = 'Add task';

  taskType: any = [];

  taskPriority: any = [];

  taskState: any = [];

  employees: any = [];

  dataSave: any = {
    Subject: '',
    PriorityID: TaskPriority.Low,
    PriorityIDText: 'Low',
    StatusID: TaskState.Pending,
    StatusIDText: 'Pending',
    AssignedUserID: '',
    AssignedUserIDText: '',
    RelatedUserID: '',
    RelatedUserIDText: '',
    FoundInBuild: '',
    IntergratedBuild: '',
    DueDate: moment(),
    CompletedProgress: 0,
    State: EntityState.Add,
    Description: ''
  };
  //#endregion

  //#region Lifecycles
  constructor(
    public dialogRef: MatDialogRef<PopupAddTaskComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private taskSV: TaskService,
    private dataSV: DataService,
    private toastSV: ToastService,
    private signalrSV: SignalrService
  ) {
    super();
    this.dataSave['ProjectID'] = data['ProjectID'];
    this.dataSV.user.pipe(takeUntil(this._onDestroySub)).subscribe((user) => {
      if (user) {
        this.dataSave['AssignedUserID'] = Number(user.id);
        this.dataSave['AssignedUserIDText'] = user.fullName;
        this.dataSave['RelatedUserID'] = Number(user.id);
        this.dataSave['RelatedUserIDText'] = user.fullName;
      }
    });
  }

  ngOnInit(): void {
    if (this.data) {
      let formMode = EntityState.Add;
      let taskID = 0;
      if (this.data['TaskID']) {
        taskID = this.data['TaskID'];
        this.saveDataToSessionStorage(taskID);
        
        formMode = EntityState.Edit;
        this.title = 'Edit task';
      }
      this.toastSV.loading();
      this.taskSV
        .getFormData(this.data['ProjectID'], taskID, formMode)
        .pipe(takeUntil(this._onDestroySub))
        .subscribe(
          (resp) => {
            this.toastSV.unLoad();
            if (resp?.Success) {
              if (resp.Data?.Dictionary) {
                // this.taskType = resp.Data.Dictionary[0];
                this.taskPriority = resp.Data.Dictionary[1].map((x: any) => {
                  return {
                    Value: Number(x.Value),
                    Text: x.Text,
                  };
                });
                // this.taskState = resp.Data.Dictionary[2];
              }
              if (resp.Data?.Employees) {
                this.employees = resp.Data.Employees.map((x: any) => {
                  return {
                    Value: x.ID,
                    Text: x.FullName,
                  };
                });
              }
              if (resp.Data?.CurrentData) {
                this.dataSave = {
                  ...resp.Data.CurrentData,
                  EntityState: EntityState.Edit,
                };
              }
            }
          },
          (error) => {
            console.log(error);
            this.toastSV.unLoad();
          }
        );
    }
  }

  ngOnDestroy(): void {
    super.ngOnDestroy();
  }

  saveDataToSessionStorage(taskID: number) {
    let tasks = JSON.parse(sessionStorage.getItem("Tasks") || '[]');
    if(tasks?.length > 0) {
      const index = tasks.indexOf(taskID);
      if(index > -1) {
        tasks.splice(index, 1);
      }
      tasks.unshift(taskID);
      if(tasks.lenth > 10) {
        tasks.pop();
      }
    } else {
      tasks.unshift(taskID);
    }
    sessionStorage.setItem("Tasks", JSON.stringify(tasks));
  }
  //#endregion
  /**
   * Th???c hi???n l??u d??? li???u
   * Author: HHDANG 14.4.2022
   */
  saveData() {
    this.toastSV.loading();
    const msg =
      this.dataSave.EntityState === EntityState.Edit
        ? SuccessMessage.UpdateTask
        : SuccessMessage.AddTask;
    this.taskSV
      .saveData(this.dataSave)
      .pipe(takeUntil(this._onDestroySub))
      .subscribe(
        (resp: AppServerResponse<any>) => {
          if (resp?.Success) {
            this.toastSV.showSuccess(msg);
            this.signalrSV.askServer(resp.Data);
          } else if (resp?.ValidateInfo && resp?.ValidateInfo.length > 0) {
            this.toastSV.showError(resp?.ValidateInfo[0]);
          } else {
            this.toastSV.showError(ErrorMessage.Exception);
          }
          this.dialogRef.close(true);
        },
        (error) => {
          console.log(error);
          this.toastSV.showError(ErrorMessage.Exception);
        }
      );
  }
  /**
   * Th???c hi???n l??u v?? th??m
   * Author: HHDANG 14.4.2022
   */
  saveAndAddData() {}

  /**
   * ????ng popup
   */
  close() {
    this.dialogRef.close();
  }

  valueChangeCombo(data: any) {
    const fieldName = data?.FieldName;
    console.log(data);
    switch (fieldName) {
      case 'DueDate':
        this.dataSave[fieldName] = data.Value;
        console.log(this.dataSave);
        break;
      default:
        this.dataSave[fieldName] = data.Value;
        this.dataSave[`${fieldName}Text`] = data.Text;
        break;
    }
  }
}
