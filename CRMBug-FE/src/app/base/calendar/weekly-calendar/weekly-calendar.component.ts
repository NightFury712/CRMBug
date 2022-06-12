import { Component, Input, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { DEFAULT_CALENDAR_OPTIONS } from 'src/app/enumeration/calendar.enum';

@Component({
  selector: 'weekly-calendar',
  templateUrl: './weekly-calendar.component.html',
  styleUrls: ['./weekly-calendar.component.scss'],
})
export class WeeklyCalendarComponent implements OnInit {
  //options cho fullcalendar
  calendarOptions: CalendarOptions = {
    ...DEFAULT_CALENDAR_OPTIONS,
    initialView: 'timeGridWeek',

    allDaySlot: false, //Không cho phép hiện ô sự kiện cả ngày

    weekText: 'T',

    navLinks: true,

    dayHeaderFormat: {
      weekday: 'narrow',
      month: 'numeric',
      day: 'numeric',
      omitCommas: true,
    },

    events: [
      { title: 'event 1', date: '2022-06-01' },
      { title: 'event 2', date: '2022-06-02' },
    ],
  };

  @Input()
  events: Array<any> = []

  constructor() {
  }

  ngOnInit(): void {
    this.calendarOptions.events = this.events;
  }
}
