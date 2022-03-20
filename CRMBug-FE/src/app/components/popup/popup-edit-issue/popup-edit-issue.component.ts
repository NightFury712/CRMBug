import { EmployeeService } from './../../../service/employee/employee.service';
import { Component, Inject, OnInit } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { TypeControl } from 'src/app/enumeration/type-control.enum';

@Component({
  selector: 'popup-edit-issue',
  templateUrl: './popup-edit-issue.component.html',
  styleUrls: ['./popup-edit-issue.component.scss']
})
export class PopupEditIssueComponent implements OnInit {
  typeControl = TypeControl;

  constructor(
      public dialogRef: MatDialogRef<PopupEditIssueComponent>,
      @Inject(MAT_DIALOG_DATA) public data: any,
      private empService: EmployeeService
    ) { }

  ngOnInit(): void {
    this.empService.getDatas().subscribe(resp => {
      console.log(resp);
    })
  }

}
