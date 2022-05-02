import { AddIssueComponent } from './../add-issue/add-issue.component';
import { ViewIssueComponent } from './../view-issue/view-issue.component';
import { ChartComponent } from './../chart/chart.component';
import { HomeComponent } from './../home/home.component';
import { ProjectComponent } from './project.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "",
    component: ProjectComponent,
    children: [
      {
        path: "home/:projectID",
        component: HomeComponent
      },
      {
        path: "add-issue/:projectID",
        component: AddIssueComponent
      },
      {
        path: "view-issue/:projectID",
        component: ViewIssueComponent
      },
      {
        path: "chart/:projectID",
        component: ChartComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
