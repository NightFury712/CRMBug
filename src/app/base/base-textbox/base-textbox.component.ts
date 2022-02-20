import { TypeControl } from './../../enumaration/type-control.enum';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'base-textbox',
  templateUrl: './base-textbox.component.html',
  styleUrls: ['./base-textbox.component.scss']
})
export class BaseTextboxComponent implements OnInit {
  @Input()
  type: number = TypeControl.Search;

  @Input()
  placeholder:string = 'Search an issue';

  @Input()
  text: string = 'Subject';

  typeControl = TypeControl;
  constructor() { }

  ngOnInit(): void {
  }

}
