import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BaseButtonComponent } from './base/base-button/base-button.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { BaseTextboxComponent } from './base/base-textbox/base-textbox.component';
import { ViewIssueComponent } from './components/view-issue/view-issue.component';
import { ChartComponent } from './components/chart/chart.component';
import { SharedComponentModule } from './components/shared-component.module';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { AddIssueComponent } from './components/add-issue/add-issue.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    PageHeaderComponent,
    ViewIssueComponent,
    ChartComponent,
    SidebarComponent,
    AddIssueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedComponentModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class AppModule { }
