import { TaskService } from 'src/app/service/task/task.service';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { BaseComponent } from 'src/app/shared/base-component';
import { NotificationService } from './../../service/notification/notification.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent implements OnInit {

  notifications: Array<any> = [];

  projectID: string = '';

  summaryData = {
    Completed: 0,
    CompletedLate: 0,
    Pending: 0,
    TotalRecord: 0
  }

  summaryStyle: any = {
    Completed: 0,
    CompletedLate: 0,
    Pending: 0,
  }

  constructor(
    private activeRoute: ActivatedRoute,
    private taskSV: TaskService
  ) { 
    super();
  }

  ngOnInit(): void {
    this.projectID = this.activeRoute.snapshot.params.projectID;
    this.getDatas()
  }

  getDatas() {
    this.taskSV.getSummaryData(Number(this.projectID))
      .pipe(takeUntil(this._onDestroySub))
      .subscribe((resp) => {
        if(resp?.Success) {
          this.summaryData = resp.Data[0];
          this.calculateSummaryStyle();
        }
      })
  }

  calculateSummaryStyle() {
    const totalRecord = this.summaryData.TotalRecord;
    this.summaryStyle.Completed += this.summaryData.Completed / totalRecord * 100 ;
    this.summaryStyle.CompletedLate += this.summaryData.CompletedLate / totalRecord * 100 ;
    this.summaryStyle.Pending += this.summaryData.Pending / totalRecord * 100 ;
  }
}
