import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddIssueComponent } from '../add-issue/add-issue.component';

const routes: Routes = [
  {path: "", redirectTo: "home", pathMatch: "full"},
  {
    path: "home",
    component: AddIssueComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class ProjectRoutingModule { }
