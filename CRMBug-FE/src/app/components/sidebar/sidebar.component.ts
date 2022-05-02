import { DataService } from './../../service/data/data.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  projectID: number = 0;

  constructor(
    private dataSV: DataService
  ) {

  }

  ngOnInit(): void {
    this.dataSV.projectID.subscribe((data) => {
      if(data != 0) {
        this.projectID = data;
      }
    })
  }

}
