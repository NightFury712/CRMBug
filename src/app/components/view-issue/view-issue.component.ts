import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { EntityState } from 'src/app/enumaration/EnittyState.enum';
import { TypeControl } from 'src/app/enumaration/type-control.enum';
declare const $: any;

@Component({
  selector: 'app-view-issue',
  templateUrl: './view-issue.component.html',
  styleUrls: ['./view-issue.component.scss']
})
export class ViewIssueComponent implements OnInit {
  issues: any = [
    {
      Type: "Bug",
      Subject: "Can't add ticket",
      Priority: "High",
      Status: "New",
      AssignedTo: "HHDANG",
      FoundInBuild: "R24.0.16",
      IntergratedBuild: "R25.0.01",
      State: EntityState.View
    }
  ];

  entityState = EntityState;

  oldData: any = {};

  typeControl = TypeControl;

  isEditing: boolean = false;

  currentData: any = {};

  constructor() { }

  ngOnInit(): void {
  }

  addIssue(e: any) {
    this.issues.push(
      {
        Type: "",
        Subject: "",
        Priority: "",
        Status: "",
        AssignedTo: "",
        FoundInBuild: "",
        IntergratedBuild: "",
        State: EntityState.View
      }
    )
  }

  clickBtnEdit(item: any, index: number) {
    this.oldData = JSON.parse(JSON.stringify(item));
    item.State = EntityState.Edit;
    if(this.isEditing) {
      const oldIndex = this.issues.indexOf(this.currentData);
      this.issues[oldIndex].State = EntityState.View;
      //Save data
    }
    this.currentData = item;
    this.isEditing = true;
  }

  cancelEdit(item: any, index: number) {
    this.issues[index] = this.oldData
    item.State = EntityState.View;
    this.isEditing = false;
  }
  
  saveIssue(item: any, index: number) {
    item.State = EntityState.View
    this.isEditing = false;
  }

  deleteIssue(item: any, index: number) {
    this.issues.splice(index, 1);
    this.isEditing = false;
  }
}
