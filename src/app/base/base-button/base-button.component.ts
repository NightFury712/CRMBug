import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'base-button',
  templateUrl: './base-button.component.html',
  styleUrls: ['./base-button.component.scss']
})
export class BaseButtonComponent implements OnInit {
  @Input()
  typeButton: string = '';

  @Input()
  text: string = '';

  @Input()
  width: number = 105;

  @Input()
  height: number = 32;
  constructor() { }

  ngOnInit(): void {
  }

}
