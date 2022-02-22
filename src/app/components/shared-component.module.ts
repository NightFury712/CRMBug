import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BaseButtonComponent } from "../base/base-button/base-button.component";
import { BaseTextboxComponent } from "../base/base-textbox/base-textbox.component";
import { HomeComponent } from './home/home.component';

@NgModule({
	declarations: [
		BaseButtonComponent,
		BaseTextboxComponent,
  		HomeComponent
	],
	imports: [
		BrowserModule,
		FormsModule,
	],
	exports: [
		BaseButtonComponent,
		BaseTextboxComponent
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SharedComponentModule { }