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
        path: "home",
        component: HomeComponent
      },
      {
        path: "add-issue",
        component: AddIssueComponent
      },
      {
        path: "view-issue",
        component: ViewIssueComponent
      },
      {
        path: "chart",
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
