import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewIssueComponent } from './components/view-issue/view-issue.component';
import { AddIssueComponent } from './components/add-issue/add-issue.component';
import { ChartComponent } from './components/chart/chart.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {path: "", redirectTo: "dashboard", pathMatch: "full"},
  {
    path: "dashboard",
    component: DashboardComponent
  },
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
