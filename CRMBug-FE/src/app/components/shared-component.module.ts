import { BaseComboboxComponent } from './../base/base-combobox/base-combobox.component';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BaseButtonComponent } from "../base/base-button/base-button.component";
import { BaseTextboxComponent } from "../base/base-textbox/base-textbox.component";
import { MatSelectModule } from '@angular/material/select'
import { MatFormFieldModule } from '@angular/material/form-field';
import { PopupEditIssueComponent } from './popup/popup-edit-issue/popup-edit-issue.component';
import { MatDialogModule } from '@angular/material/dialog'

@NgModule({
	declarations: [
		BaseButtonComponent,
		BaseTextboxComponent,
		BaseComboboxComponent,
  	PopupEditIssueComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
		MatSelectModule,
		MatFormFieldModule,
		MatDialogModule
	],
	exports: [
		BaseButtonComponent,
		BaseTextboxComponent,
		BaseComboboxComponent
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SharedComponentModule { }