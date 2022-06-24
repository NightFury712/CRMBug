import { PopupAddTaskComponent } from './../popup/popup-add-task/popup-add-task.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Addition } from 'src/app/enumeration/addition.enum';
import { CalendarType } from 'src/app/enumeration/calendar.enum';
import { EntityState } from 'src/app/enumeration/entity-state.enum';
import { Operator } from 'src/app/enumeration/operator.enum';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { ConfigDialog } from 'src/app/modules/config-dialog';
import { DataService } from 'src/app/service/data/data.service';
import { TaskService } from 'src/app/service/task/task.service';
import { TaskView } from 'src/app/enumeration/task.enum';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.scss'],
})
export class ViewTaskComponent implements OnInit {
  _onDestroySub: Subject<void> = new Subject<void>();

  currentView: TaskView = TaskView.List;

  taskView = TaskView;

  calendarType = CalendarType;

  currCalendarType: CalendarType = CalendarType.MonthLy;

  fieldDisplay: Array<any> = [
    {
      fieldName: 'Subject',
      displayText: 'Subject',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'PriorityID',
      displayText: 'Priority',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'CompletedProgress',
      displayText: 'Completed progress',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'Description',
      displayText: 'Description',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'AssignedUserIDText',
      displayText: 'Assigned to',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'RelatedUserIDText',
      displayText: 'Related to',
      typeControl: TypeControl.Textbox,
    },
    {
      fieldName: 'CreatedDate',
      displayText: 'Created date',
      typeControl: TypeControl.DateTime,
    },
    {
      fieldName: 'DueDate',
      displayText: 'Deadline',
      typeControl: TypeControl.DateTime,
    },
  ];

  tasks: Array<any> = [];

  pageSizeCbx = [
    {
      Value: 10,
      Text: '10 records/page',
    },
    {
      Value: 20,
      Text: '20 records/page',
    },
    {
      Value: 50,
      Text: '50 records/page',
    },
    {
      Value: 100,
      Text: '100 records/page',
    },
  ];

  assignedUserCbx: Array<any> = [];

  assignedUserID: number = -1;

  currentPage = 1;

  totalRecord = 0;

  fromRecord = 1;

  toRecord = 1;

  configPaging: any = {
    Filters: [
      {
        FieldName: 'ProjectID',
        Value: '0',
        Addition: Addition.And,
        IsFormula: false,
        Operator: Operator.Equal,
      },
      {
        FieldName: 'Subject',
        Value: '',
        Addition: Addition.Or,
        IsFormula: true,
        Operator: Operator.Like,
      },
      {
        FieldName: 'AssignedUserIDText',
        Value: '',
        Addition: Addition.Or,
        IsFormula: true,
        Operator: Operator.Like,
      },
      {
        FieldName: 'RelatedUserIDText',
        Value: '',
        Addition: Addition.Or,
        IsFormula: true,
        Operator: Operator.Like,
      },
    ],
    PageIndex: 0,
    Formula: '({0} OR {1} OR {2})',
    PageSize: 20,
    Columns: btoa(
      'ID,Subject,PriorityID,PriorityIDText,StatusID,StatusIDText,CompletedProgress,AssignedUserID,AssignedUserIDText,RelatedUserID,RelatedUserIDText,ProjectID,DueDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate'
    ),
  };

  entityState = EntityState;

  oldData: any = {};

  typeControl = TypeControl;

  isEditing: boolean = false;

  currentData: any = {};

  projectID: number = 0;

  constructor(
    private taskSV: TaskService,
    private dialog: MatDialog,
    private activeRoute: ActivatedRoute,
    private dataSV: DataService,
    private toastSV: ToastrService
  ) {}

  ngOnInit() {
    this.projectID = this.activeRoute.snapshot.params.projectID;
    this.configPaging.Filters[0].Value = this.projectID;
    this.dataSV.user
      .pipe(takeUntil(this._onDestroySub))
      .subscribe((user) => {
        if(user) {
          this.assignedUserCbx = [
            {
              Value: -1,
              Text: "All task"
            },
            {
              Value: user.id,
              Text: "Assigned to me"
            }
          ]
        }
      })
    this.getDataPaging();
  }

  getDataPaging() {
    this.dataSV.loading.next(true);
    this.configPaging.PageIndex =
      (this.currentPage - 1) * this.configPaging.PageSize;
    this.taskSV
      .grid(this.configPaging)
      .pipe(takeUntil(this._onDestroySub))
      .subscribe(
        (resp) => {
          this.dataSV.loading.next(false);
          if (resp && resp.Success) {
            this.tasks = resp.Data.Data.map((x: any) => {
              return {
                ...x,
                title: x.Subject,
                date: x.CreatedDate,
              };
            });
            this.totalRecord = resp.Data.TotalRecord;
          } else {
            console.log(resp);
          }
        },
        (error) => {
          this.dataSV.loading.next(false);
          console.log(error);
        }
      );
  }

  addTask(e: any) {
    const config = new ConfigDialog('800px');
    config.data = {
      ProjectID: this.projectID,
    };
    const dialogRef = this.dialog.open(PopupAddTaskComponent, config);
    dialogRef.afterClosed().subscribe((resp) => {
      if (resp) {
        this.getDataPaging();
      }
    });
  }

  clickBtnEdit(item: any, index: number) {
    // this.oldData = JSON.parse(JSON.stringify(item));
    // item.State = EntityState.Edit;
    // item.EntityState = EntityState.Edit;
    // if(this.isEditing) {
    //   const oldIndex = this.tasks.indexOf(this.currentData);
    //   this.tasks[oldIndex].State = EntityState.View;
    //   //Save data
    //   this.taskSV.addTask(item).subscribe(
    //     resp => {
    //       console.log(resp);
    //     }
    //   )
    // }
    // this.currentData = item;
    // this.isEditing = true;
  }

  switchView(viewType: TaskView) {
    if (viewType === TaskView.Calendar) {
      this.currCalendarType = CalendarType.MonthLy;
    }
    this.currentView = viewType;
  }

  switchcalendarType(calendarType: CalendarType) {
    this.currCalendarType = calendarType;
  }

  cancelEdit(item: any, index: number) {
    this.isEditing = false;
    if (item.State == EntityState.Add) {
      this.tasks.splice(index, 1);
      return;
    }
    this.tasks[index] = this.oldData;
    item.State = EntityState.View;
  }

  saveTask(item: any, index: number) {
    // item.State = EntityState.View
    // this.isEditing = false;
    // this.mappingData(item);
    // // Save data
    // this.taskSV.addTask(item).subscribe(
    //   resp => {
    //     console.log(resp);
    //   }
    // )
  }

  editTask(task: any) {
    const config = new ConfigDialog('800px');
    config.data = {
      ProjectID: this.projectID,
      TaskID: task.ID,
    };
    const dialogRef = this.dialog.open(PopupAddTaskComponent, config);
    dialogRef.afterClosed().subscribe((resp) => {
      if (resp) {
        this.getDataPaging();
      }
    });
  }

  deleteTask(item: any, index: number) {
    this.tasks.splice(index, 1);
    this.isEditing = false;
    this.taskSV.delete(item.ID).subscribe((resp) => {
      console.log(resp);
    });
  }

  valueChangeCombo(e: any) {
    if (e) {
      switch (e.FieldName) {
        case 'PageSize':
          this.configPaging.PageSize = e.Value;
          break;
        case 'AssignedUserID': 
          if(e.Value == -1) {
            this.configPaging.Filters = this.configPaging.Filters.filter((x:any) => x.FieldName != 'AssignedUserID')
          } else {
            this.configPaging.Filters.push({
              FieldName: 'AssignedUserID',
              Value: e.Value,
              Addition: Addition.And,
              IsFormula: false,
              Operator: Operator.Equal,
            });
          }
          break;
      }
    }
    this.getDataPaging();
  }

  searchTask(data: any) {
    console.log(data);
    this.configPaging.Filters.forEach((x: any) => {
      if(x.IsFormula) {
        x.Value = data.trim();
      }
    })
    this.getDataPaging();
  }

  calculateRecord() {
    this.fromRecord =
      this.totalRecord > 0
        ? (this.currentPage - 1) * this.configPaging.PageSize + 1
        : 0;
    this.toRecord =
      this.currentPage * this.configPaging.PageSize < this.totalRecord
        ? this.currentPage * this.configPaging.PageSize
        : this.toRecord;
  }

  prevFirst() {
    if (this.currentPage > 1) {
      this.currentPage = 1;
    }
  }

  prevOne() {
    if (this.currentPage > 1) {
      this.currentPage--;
    }
  }

  nextLast() {
    if (
      (this.currentPage + 1) * this.configPaging.PageSize >
      this.totalRecord
    ) {
      this.currentPage = this.totalRecord / this.configPaging.PageSize;
    }
  }

  nextOne() {
    if (
      (this.currentPage + 1) * this.configPaging.PageSize >
      this.totalRecord
    ) {
      this.currentPage++;
    }
  }
}
