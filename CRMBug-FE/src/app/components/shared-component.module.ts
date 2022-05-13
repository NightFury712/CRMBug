import { BaseNotificationComponent } from '../base/base-notification/base-notification.component';
import { BaseComboboxComponent } from './../base/base-combobox/base-combobox.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BaseButtonComponent } from "../base/base-button/base-button.component";
import { BaseTextboxComponent } from "../base/base-textbox/base-textbox.component";
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { PopupEditIssueComponent } from './popup/popup-edit-issue/popup-edit-issue.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { PopupAddProjectComponent } from './popup/popup-add-project/popup-add-project.component';
import { AuthComponent } from './auth/auth.component';
import { PopupUpdateUserSettingComponent } from './popup/popup-update-user-setting/popup-update-user-setting.component';
import { RegisterComponent } from './register/register.component';
import {MatInputModule} from '@angular/material/input';
import { LoadingComponent } from '../base/loading/loading.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
	declarations: [
		BaseButtonComponent,
		BaseTextboxComponent,
		BaseComboboxComponent,
		BaseNotificationComponent,
  	PopupEditIssueComponent,
   	PopupAddProjectComponent,
   	AuthComponent,
    PopupUpdateUserSettingComponent,
    RegisterComponent,
		LoadingComponent,
	],
	imports: [
		BrowserModule,
		FormsModule,
		MatSelectModule,
		MatFormFieldModule,
		MatTooltipModule,
		MatDialogModule,
		MatInputModule
	],
	exports: [
		BaseButtonComponent,
		BaseTextboxComponent,
		BaseComboboxComponent,
		BaseNotificationComponent,
		LoadingComponent,
		AppRoutingModule,
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SharedComponentModule { }