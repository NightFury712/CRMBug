import { IssueState } from './../../../enumeration/issue-state.enum';
import { IssuePriority } from './../../../enumeration/issue-priority.enum';
import { EntityState } from './../../../enumeration/entity-state.enum';
import { IssueService } from './../../../service/issue/issue.service';
import { EmployeeService } from './../../../service/employee/employee.service';
import { Component, Inject, OnInit } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { IssueType } from 'src/app/enumeration/issue-type.enum';

@Component({
  selector: 'popup-edit-issue',
  templateUrl: './popup-edit-issue.component.html',
  styleUrls: ['./popup-edit-issue.component.scss']
})
export class PopupEditIssueComponent implements OnInit {
  typeControl = TypeControl;

  issueType: any = [];

  issuePriority: any = [];
  
  issueState: any = [];

  inputData: any = {
    TypeID: IssueType.Task,
    TypeIDText: "Task",
    Subject: "",
    PriorityID: IssuePriority.Low,
    PriorityIDText: "Low",
    StatusID: IssueState.New,
    StatusIDText: "New",
    AssignedTo: "",
    FoundInBuild: "",
    IntergratedBuild: "",
    State: EntityState.View
  }

  constructor(
      public dialogRef: MatDialogRef<PopupEditIssueComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
      private empService: EmployeeService,
      private issueService: IssueService,
    ) { }

  ngOnInit(): void {
    this.empService.getDatas().subscribe(resp => {
      console.log(resp);
    });
    this.issueService.getDictionary().subscribe(resp => {
      if(resp && resp.Data && resp.Data.Dictionary) {
        this.issueType = resp.Data.Dictionary[0];
        this.issuePriority = resp.Data.Dictionary[1];
        this.issueState = resp.Data.Dictionary[2];
      }
    })
  }

}
