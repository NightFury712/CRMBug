import { Component, Input, OnInit } from '@angular/core';
import { CalendarType } from 'src/app/enumeration/calendar.enum';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  calendarType = CalendarType;

  @Input()
  type: CalendarType = CalendarType.MonthLy;

  @Input()
  events: Array<any> = [
    { title: 'event 1', date: '2022-06-01' },
    { title: 'event 2', date: '2022-06-02' },
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
