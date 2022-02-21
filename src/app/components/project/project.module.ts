import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AddIssueComponent } from "../add-issue/add-issue.component";
import { SharedComponentModule } from "../shared-component.module";
import { SidebarComponent } from "../sidebar/sidebar.component";
import { ProjectRoutingModule } from "./project-routing.module";
import { ProjectComponent } from "./project.component";

@NgModule({
    declarations: [
      ProjectComponent,
      SidebarComponent,
      AddIssueComponent,
    ],
    imports: [
      BrowserModule,
      ProjectRoutingModule,
      SharedComponentModule
    ],
    providers: [],
    bootstrap: [ProjectComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
  })
  export class ProjectModule { }