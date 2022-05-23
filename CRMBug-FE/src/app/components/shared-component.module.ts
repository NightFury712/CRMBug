import { BaseDatetimepickerComponent } from './../base/base-datetimepicker/base-datetimepicker.component';
import { BaseNotificationComponent } from '../base/base-notification/base-notification.component';
import { BaseComboboxComponent } from './../base/base-combobox/base-combobox.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
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
import { ProjectSettingsComponent } from './project-settings/project-settings.component';
import {MatTabsModule} from '@angular/material/tabs';
import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatNativeDateModule } from '@angular/material/core';
import { NgxMatMomentModule } from '@angular-material-components/moment-adapter';

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
  	ProjectSettingsComponent,
		BaseDatetimepickerComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		MatSelectModule,
		MatFormFieldModule,
		MatTooltipModule,
		MatDialogModule,
		MatInputModule,
		MatTabsModule,
		HttpClientModule,
		BrowserAnimationsModule,
		MatDatepickerModule,
		NgxMatTimepickerModule,
		ReactiveFormsModule,
		MatButtonModule,
		NgxMatDatetimePickerModule,
		MatNativeDateModule,
		NgxMatMomentModule
	],
	exports: [
		BaseButtonComponent,
		BaseTextboxComponent,
		BaseComboboxComponent,
		BaseNotificationComponent,
		BaseDatetimepickerComponent,
		LoadingComponent,
		AppRoutingModule,
	]
})
export class SharedComponentModule { }