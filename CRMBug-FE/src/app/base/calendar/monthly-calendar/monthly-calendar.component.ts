import { Component, Input, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import { DEFAULT_CALENDAR_OPTIONS } from 'src/app/enumeration/calendar.enum';

@Component({
  selector: 'monthly-calendar',
  templateUrl: './monthly-calendar.component.html',
  styleUrls: ['./monthly-calendar.component.scss'],
})
export class MonthlyCalendarComponent implements OnInit {
  calendarOptions: CalendarOptions = {
    ...DEFAULT_CALENDAR_OPTIONS,

    initialView: 'dayGridMonth',

    stickyHeaderDates: false,

    selectable: true,

    navLinks: true,

    weekNumbers: true,

    eventDisplay: 'block',

    events: [
      { title: 'event 1', date: '2022-06-01' },
      { title: 'event 2', date: '2022-06-02' },
    ],
    /**
     * Hàm xử lý khi bấm vào 1 event
     * @param info
     */
    // eventClick: (info) => {
    //     console.log(info);
    //     this.eventClick.emit(info);
    // },
  };

  @Input()
  events: Array<any> = [];

  constructor() {
    
  }

  ngOnInit(): void {
    this.calendarOptions.events = this.events;
  }
}
