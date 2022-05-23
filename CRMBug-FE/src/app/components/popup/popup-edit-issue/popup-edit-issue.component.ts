import { IssueState } from './../../../enumeration/issue-state.enum';
import { IssuePriority } from './../../../enumeration/issue-priority.enum';
import { EntityState } from './../../../enumeration/entity-state.enum';
import { IssueService } from './../../../service/issue/issue.service';
import { EmployeeService } from './../../../service/employee/employee.service';
import { Component, Inject, OnInit, Input } from '@angular/core';
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

  employees: any = []

  dataSave: any = {
    TypeID: IssueType.Task,
    TypeIDText: "Task",
    Subject: "",
    PriorityID: IssuePriority.Low,
    PriorityIDText: "Low",
    StatusID: IssueState.New,
    StatusIDText: "New",
    AssignedUserID: "",
    FoundInBuild: "",
    IntergratedBuild: "",
    State: EntityState.Add
  }

  constructor(
      public dialogRef: MatDialogRef<PopupEditIssueComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
      private empService: EmployeeService,
      private issueService: IssueService
    ) { 
      this.dataSave["ProjectID"] = data["ProjectID"];
    }

  ngOnInit(): void {
    this.empService.getDatas().subscribe(resp => {
      if(resp && resp.Success) {
        this.employees = resp.Data.map((x: any) => {
          return {
            Value: x.ID,
            Text: x.FullName
          }
        });
      }
    });
    this.issueService.getDictionary().subscribe(resp => {
      if(resp && resp.Data && resp.Data.Dictionary) {
        this.issueType = resp.Data.Dictionary[0];
        this.issuePriority = resp.Data.Dictionary[1];
        this.issueState = resp.Data.Dictionary[2];
      }
    })
  }
  /**
   * Thực hiện lưu dữ liệu
   * Author: HHDANG 14.4.2022
   */
  saveData() {
    this.issueService.saveData(this.dataSave).subscribe(
      resp => {
        console.log(resp);
        this.dialogRef.close(true);
      }
    )
  }
  /**
   * Thực hiện lưu và thêm
   * Author: HHDANG 14.4.2022
   */
  saveAndAddData() {
    
  }
  /**
   * Đóng popup
   */
  close() {
    this.dialogRef.close();
  }

  valueChangeCombo(data: any) {
    const fieldName = data.FieldName;
    this.dataSave[fieldName] = data.Value;
    this.dataSave[`${fieldName}Text`] = data.Text;
  }
}
