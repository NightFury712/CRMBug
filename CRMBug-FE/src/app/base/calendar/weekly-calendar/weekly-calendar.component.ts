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
    initialView: 'dayGridWeek',

    allDaySlot: false, //Không cho phép hiện ô sự kiện cả ngày

    weekText: 'T',

    navLinks: true,

    dayHeaderFormat: {
      weekday: 'narrow',
      month: 'numeric',
      day: 'numeric',
      omitCommas: true,
    },

    eventDisplay: 'block',

    events: [],
  };

  @Input()
  events: Array<any> = []

  constructor() {
  }

  ngOnInit(): void {
    this.calendarOptions.events = this.events;
  }
}
