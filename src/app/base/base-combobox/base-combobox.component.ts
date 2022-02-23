import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output, forwardRef } from '@angular/core';

@Component({
  selector: 'base-combobox',
  templateUrl: './base-combobox.component.html',
  styleUrls: ['./base-combobox.component.scss']
})
export class BaseComboboxComponent implements OnInit {
  selected = 'option2';
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

  onSelectionChange() {
    console.log(this.value)
    this.valueChange.emit(this.value);
  }
}
