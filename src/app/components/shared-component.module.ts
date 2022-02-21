import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BaseButtonComponent } from "../base/base-button/base-button.component";
import { BaseTextboxComponent } from "../base/base-textbox/base-textbox.component";

@NgModule({
	declarations: [
		BaseButtonComponent,
		BaseTextboxComponent
	],
	imports: [
		BrowserModule,
	],
	exports: [
		BaseButtonComponent,
		BaseTextboxComponent
	],
	schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class SharedComponentModule { }