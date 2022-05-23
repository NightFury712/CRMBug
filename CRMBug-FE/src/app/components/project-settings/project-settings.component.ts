import { TypeControl } from 'src/app/enumeration/type-control.enum';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-project-settings',
  templateUrl: './project-settings.component.html',
  styleUrls: ['./project-settings.component.scss']
})
export class ProjectSettingsComponent implements OnInit {
  typeControl = TypeControl;

  data = {
    ProjectName: '',
    ProjectCode: '',
  }

  tabIndex = 1;

  constructor() { }

  ngOnInit(): void {
  }

  switchTab(e: any, index: number) {
    this.tabIndex = index;
  }

  saveData(e: any) {

  }
}
