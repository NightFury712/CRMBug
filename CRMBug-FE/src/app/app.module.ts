import { MatTooltipModule } from '@angular/material/tooltip';
import { SharedComponentModule } from './components/shared-component.module';
import { AddIssueComponent } from './components/add-issue/add-issue.component';
import { ProjectComponent } from './components/project/project.component';
import { CustomerComponent } from './components/customer/customer.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatMenuModule} from '@angular/material/menu';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { ViewIssueComponent } from './components/view-issue/view-issue.component';
import { ChartComponent } from './components/chart/chart.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FullCalendarModule } from '@fullcalendar/angular';


import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import timeGridPlugin from '@fullcalendar/timegrid';
import bootstrapPlugin from '@fullcalendar/bootstrap';

FullCalendarModule.registerPlugins([
  dayGridPlugin,
  interactionPlugin,
  timeGridPlugin,
  bootstrapPlugin
])

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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedComponentModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    HttpClientModule,
    MatMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
