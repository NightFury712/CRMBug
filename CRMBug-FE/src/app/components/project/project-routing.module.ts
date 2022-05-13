import { AddIssueComponent } from './../add-issue/add-issue.component';
import { ViewIssueComponent } from './../view-issue/view-issue.component';
import { ChartComponent } from './../chart/chart.component';
import { HomeComponent } from './../home/home.component';
import { ProjectComponent } from './project.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guard/auth.guard';

const routes: Routes = [
  {
    path: "",
    component: ProjectComponent,
    children: [
      {
        path: "home/:projectID",
        component: HomeComponent,
        canActivate: [AuthGuard]
      },
      {
        path: "add-issue/:projectID",
        component: AddIssueComponent,
        canActivate: [AuthGuard]
      },
      {
        path: "view-issue/:projectID",
        component: ViewIssueComponent,
        canActivate: [AuthGuard]
      },
      {
        path: "chart/:projectID",
        component: ChartComponent,
        canActivate: [AuthGuard]
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
