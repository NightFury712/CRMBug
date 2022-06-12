import { IssueView } from './../../enumeration/issue.enum';
import { catchError, takeUntil } from 'rxjs/operators';
import { Operator } from './../../enumeration/operator.enum';
import { Addition } from './../../enumeration/addition.enum';
import { ActivatedRoute } from '@angular/router';
import { DataService } from './../../service/data/data.service';
import { PopupEditIssueComponent } from './../popup/popup-edit-issue/popup-edit-issue.component';
import { MatDialog } from '@angular/material/dialog';
import { IssueService } from '../../service/issue/issue.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { EntityState } from 'src/app/enumeration/entity-state.enum';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { ConfigDialog } from 'src/app/modules/config-dialog';
import { Subject } from 'rxjs';
declare const $: any;

@Component({
  selector: 'app-view-issue',
  templateUrl: './view-issue.component.html',
  styleUrls: ['./view-issue.component.scss']
})
export class ViewIssueComponent implements OnInit {
  _onDestroySub: Subject<void> = new Subject<void>();

  currentView: IssueView = IssueView.List;

  issueView = IssueView;

  issues: any = [];

  pageSizeCbx = [
    {
      Value: 10,
      Text: "10 records/page"
    },
    {
      Value: 20,
      Text: "20 records/page"
    },
    {
      Value: 50,
      Text: "50 records/page"
    },
    {
      Value: 100,
      Text: "100 records/page"
    },
  ]

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
        Operator: Operator.Equal
      }
    ],
    PageIndex: 0,
    PageSize: 20,
    Columns: btoa("ID ,TypeID ,TypeIDText ,Subject ,PriorityID ,PriorityIDText ,StatusID ,StatusIDText ,AssignedTo ,FoundInBuild ,IntergratedBuild ,CreatedBy ,CreatedDate ,ModifiedBy ,ModifiedDate ,AssignedUserID ,AssignedUserIDText ,ProjectID ,ProjectIDText")
  }

  entityState = EntityState;

  oldData: any = {};

  typeControl = TypeControl;

  isEditing: boolean = false;

  currentData: any = {};

  projectID: number = 0;

  constructor(
    private issueSV: IssueService,
    private dialog: MatDialog,
    private activeRoute: ActivatedRoute,
    private dataSV: DataService
  ) { 

  }

  ngOnInit() {
    this.projectID = this.activeRoute.snapshot.params.projectID;
    this.configPaging.Filters[0].Value = this.projectID;
    this.getDataPaging();
  }

  getDataPaging() {
    // this.dataSV.loading.next(true);
    this.configPaging.PageIndex = (this.currentPage - 1) * this.configPaging.PageSize;
    this.issueSV.grid(this.configPaging)
      .pipe(takeUntil(this._onDestroySub))
      .subscribe(resp => {
        this.dataSV.loading.next(false);
        if(resp && resp.Success) {
          this.issues = resp.Data.Data;
          this.totalRecord = resp.Data.TotalRecord
        } else {
          console.log(resp)
        }
      },
      error => {
        this.dataSV.loading.next(false);
        console.log(error);
      }) 
  }

  addIssue(e: any) {
    const config = new ConfigDialog('800px');
    config.data = {
      ProjectID: this.projectID
    }
    const dialogRef = this.dialog.open(PopupEditIssueComponent, config);
    dialogRef.afterClosed().subscribe(resp => {
      if(resp) {
        this.getDataPaging()
      }
    })
  }

  clickBtnEdit(item: any, index: number) {
    // this.oldData = JSON.parse(JSON.stringify(item));
    // item.State = EntityState.Edit;
    // item.EntityState = EntityState.Edit;
    // if(this.isEditing) {
    //   const oldIndex = this.issues.indexOf(this.currentData);
    //   this.issues[oldIndex].State = EntityState.View;
    //   //Save data
    //   this.issueSV.addIssue(item).subscribe(
    //     resp => {
    //       console.log(resp);
    //     }
    //   )
    // }
    // this.currentData = item;
    // this.isEditing = true;
  }

  switchView(viewType: IssueView) {
    this.currentView = viewType;
  }

  cancelEdit(item: any, index: number) {
    this.isEditing = false;
    if(item.State == EntityState.Add) {
      this.issues.splice(index, 1);
      return;
    }
    this.issues[index] = this.oldData
    item.State = EntityState.View;
  }
  
  saveIssue(item: any, index: number) {
    // item.State = EntityState.View
    // this.isEditing = false;
    // this.mappingData(item);
    // // Save data
    // this.issueSV.addIssue(item).subscribe(
    //   resp => {
    //     console.log(resp);
    //   }
    // )
  }

  editIssue(issue: any) {
    const config = new ConfigDialog('800px');
    config.data = {
      ProjectID: this.projectID,
      IssueID: issue.ID
    }
    const dialogRef = this.dialog.open(PopupEditIssueComponent, config);
    dialogRef.afterClosed().subscribe(resp => {
      if(resp) {
        this.getDataPaging()
      }
    })
  }

  deleteIssue(item: any, index: number) {
    this.issues.splice(index, 1);
    this.isEditing = false;
    this.issueSV.delete(item.ID).subscribe(resp => {
      console.log(resp);
    })
  }

  valueChangeCombo(e: any) {
    if(e) {
      switch(e.FieldName) {
        case 'PageSize':
          this.configPaging.PageSize = e.Value;
          break;
      }
    }
  }

  calculateRecord() {
    this.fromRecord = this.totalRecord > 0 ? (this.currentPage - 1) * this.configPaging.PageSize + 1 : 0;
    this.toRecord = this.currentPage * this.configPaging.PageSize <  this.totalRecord ? this.currentPage * this.configPaging.PageSize : this.toRecord;
  }

  prevFirst() {
    if(this.currentPage> 1) {
      this.currentPage = 1
    }
  }

  prevOne() {
    if(this.currentPage > 1) {
      this.currentPage--;
    }
  }

  nextLast() {
    if((this.currentPage + 1) * this.configPaging.PageSize > this.totalRecord) {
      this.currentPage = this.totalRecord / this.configPaging.PageSize;
    }
  }

  nextOne() {
    if((this.currentPage + 1) * this.configPaging.PageSize > this.totalRecord) {
      this.currentPage++;
    }
  }
}
