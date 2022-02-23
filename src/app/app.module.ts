import { SharedComponentModule } from './components/shared-component.module';
import { AddressComponent } from './components/address/address.component';
import { AddIssueComponent } from './components/add-issue/add-issue.component';
import { ProjectComponent } from './components/project/project.component';
import { CustomerComponent } from './components/customer/customer.component';
import { HomeComponent } from './components/home/home.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { ViewIssueComponent } from './components/view-issue/view-issue.component';
import { ChartComponent } from './components/chart/chart.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    PageHeaderComponent,
    HomeComponent,
    CustomerComponent,
    ProjectComponent,
    SidebarComponent,
    AddIssueComponent,
    ViewIssueComponent,
    ChartComponent,
    AddressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedComponentModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class AppModule { }
