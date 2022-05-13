import { AuthGuard } from './guard/auth.guard';
import { RegisterComponent } from './components/register/register.component';
import { AuthComponent } from './components/auth/auth.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: AuthComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'project',
    loadChildren: () =>
      import('./components/project/project.module').then(
        (m) => m.ProjectModule
      ),
      canActivate: [AuthGuard]
  },
  {
    path: 'customer',
    loadChildren: () =>
      import('./components/customer/customer.module').then(
        (m) => m.CustomerModule
      ),
      canActivate: [AuthGuard]
  },
  {
    path: '**',
    component: DashboardComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
