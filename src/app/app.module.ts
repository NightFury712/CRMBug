import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BaseButtonComponent } from './base/base-button/base-button.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { BaseTextboxComponent } from './base/base-textbox/base-textbox.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { AddIssueComponent } from './components/add-issue/add-issue.component';
import { ViewIssueComponent } from './components/view-issue/view-issue.component';
import { ProjectComponent } from './components/project/project.component';
import { ChartComponent } from './components/chart/chart.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    BaseButtonComponent,
    PageHeaderComponent,
    BaseTextboxComponent,
    SidebarComponent,
    AddIssueComponent,
    ViewIssueComponent,
    ProjectComponent,
    ChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
