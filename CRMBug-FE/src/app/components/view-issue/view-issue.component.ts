import { IssueService } from './../../service/issue.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { EntityState } from 'src/app/enumaration/entity-state.enum';
import { TypeControl } from 'src/app/enumaration/type-control.enum';
declare const $: any;

@Component({
  selector: 'app-view-issue',
  templateUrl: './view-issue.component.html',
  styleUrls: ['./view-issue.component.scss']
})
export class ViewIssueComponent implements OnInit {
  issues: any = [
    // {
    //   TypeID: 0,
    //   TypeIDText: "Task",
    //   Subject: "Can't add ticket",
    //   PriorityID: 1,
    //   PriorityIDText: "Normal",
    //   StatusID: 1,
    //   StatusIDText: "Approved",
    //   AssignedTo: "HHDANG",
    //   FoundInBuild: "R24.0.16",
    //   IntergratedBuild: "R25.0.01",
    //   State: EntityState.View
    // }
  ];

  typeOfIssue =  [
    {
      value: 0,
      valueText: "Task"
    },
    {
      value: 1,
      valueText: "Bug"
    },
    {
      value: 2,
      valueText: "Request"
    },
    {
      value: 3,
      valueText: "Orther"
    },
  ]

  priorities = [
    {
      value: 0,
      valueText: "Low"
    },
    {
      value: 1,
      valueText: "Normal"
    },
    {
      value: 2,
      valueText: "High"
    },
  ]

  issueState = [
    {
      value: 0,
      valueText: "New"
    },
    {
      value: 1,
      valueText: "Approved"
    },
    {
      value: 2,
      valueText: "Commited"
    },
    {
      value: 3,
      valueText: "Done"
    },
    {
      value: 4,
      valueText: "Removed"
    },
  ]

  entityState = EntityState;

  oldData: any = {};

  typeControl = TypeControl;

  isEditing: boolean = false;

  currentData: any = {};

  constructor(private service: IssueService) { }

  ngOnInit() {
    this.service.getIssues().subscribe(resp => {
      if(resp && resp.Success) {
        this.issues = resp.Data.map((item: any) =>  
          {
            return {
              ...item,
              State: EntityState.View,
              EntityState: EntityState.Edit
            }
          });
      } else {
        console.log(resp)
      }
    });
  }

  addIssue(e: any) {
    this.issues.push(
      {
        TypeID: 0,
        TypeIDText: "Task",
        Subject: "",
        PriorityID: 0,
        PriorityIDText: "Low",
        StatusID: 0,
        StatusIDText: "New",
        AssignedTo: "",
        FoundInBuild: "",
        IntergratedBuild: "",
        State: EntityState.Add,
        EntityState: EntityState.Add
      }
    )
  }

  clickBtnEdit(item: any, index: number) {
    this.oldData = JSON.parse(JSON.stringify(item));
    item.State = EntityState.Edit;
    item.EntityState = EntityState.Edit;
    if(this.isEditing) {
      const oldIndex = this.issues.indexOf(this.currentData);
      this.issues[oldIndex].State = EntityState.View;
      this.mappingData(this.issues[oldIndex]);
      //Save data
      this.service.addIssue(item).subscribe(
        resp => {
          console.log(resp);
        }
      )
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
    this.mappingData(item);
    // Save data
    this.service.addIssue(item).subscribe(
      resp => {
        console.log(resp);
      }
    )
  }

  deleteIssue(item: any, index: number) {
    this.issues.splice(index, 1);
    this.isEditing = false;
    this.service.delete(item.ID).subscribe(resp => {
      console.log(resp);
    })
  }

  mappingData(item: any) {
    item.TypeIDText = this.typeOfIssue.find(toi => toi.value == item.TypeID)?.valueText;
    item.PriorityIDText = this.priorities.find(p => p.value == item.PriorityID)?.valueText;
    item.StatusIDText = this.issueState.find(is => is.value == item.StatusID)?.valueText;
  }
}