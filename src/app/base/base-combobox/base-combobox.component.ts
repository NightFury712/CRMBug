import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output, forwardRef } from '@angular/core';

@Component({
  selector: 'base-combobox',
  templateUrl: './base-combobox.component.html',
  styleUrls: ['./base-combobox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => BaseComboboxComponent),
      multi: true
    }
  ]
})
export class BaseComboboxComponent implements OnInit, ControlValueAccessor {
  @Input()
  datas: any[] = [];
  
  @Input()
  value: any;

  @Output()
  valueChange = new EventEmitter();
  change = (data: any) => {};
  constructor() { }

  ngOnInit(): void {
  }

  writeValue(obj: any) {
    this.value = obj;
    this.change(obj);
  }

  registerOnChange(fn: any) {
  }

  registerOnTouched(fn: any) {
  }

  setDisabledState(isDisabled: boolean) {
  }

  onChange() {
    this.valueChange.emit(this.value);
  }
}
