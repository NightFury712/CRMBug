import { TypeControl } from './../../enumeration/type-control.enum';
import { Component, forwardRef, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'base-textbox',
  templateUrl: './base-textbox.component.html',
  styleUrls: ['./base-textbox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => BaseTextboxComponent),
      multi: true
    }
  ]
})
export class BaseTextboxComponent implements OnInit, ControlValueAccessor  {
  @Input()
  type: number = TypeControl.Search;

  @Input()
  placeholder:string = 'Search an issue';

  @Input()
  text: string = 'Subject';

  @Input() 
  value: string = "";

  @Input()
  isLabel: boolean = true;

  @Output()
  valueChange = new EventEmitter();

  typeControl = TypeControl;
  change = (data: any) => {};
  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

  writeValue(obj: any) {
    this.value = obj;
    this.change(this.value);
  }

  registerOnChange(fn: any) {
  }

  registerOnTouched(fn: any) {
  }

  setDisabledState(isDisabled: boolean) {
  }

  onInput() {
    this.valueChange.emit(this.value);
  }
}
