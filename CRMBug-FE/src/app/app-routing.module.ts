import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "", 
    redirectTo: "dáhboard",
    pathMatch: "full"
  },
  {
    path: "dashboard",
    component: DashboardComponent
  },
  {
    path: "project",
    loadChildren: () => import("./components/project/project.module").then(m => m.ProjectModule)
  },
  {
    path: "customer",
    loadChildren: () => import("./components/customer/customer.module").then(m => m.CustomerModule)
  },
  {
    path: "**",
    component: DashboardComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
