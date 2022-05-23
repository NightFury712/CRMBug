import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import * as moment from 'moment';

@Component({
  selector: 'base-datetimepicker',
  templateUrl: './base-datetimepicker.component.html',
  styleUrls: ['./base-datetimepicker.component.scss']
})
export class BaseDatetimepickerComponent implements OnInit {

  public date: moment.Moment = moment();
  public disabled = false;
  public showSpinners = true;
  public showSeconds = true;
  public touchUi = false;
  public enableMeridian = false;
  public minDate: moment.Moment = moment().subtract(20, "year");
  public maxDate: moment.Moment= moment().add(5, "year");
  public stepHour = 1;
  public stepMinute = 1;
  public stepSecond = 1;
  public color: ThemePalette = 'primary';

  public dateControl = new FormControl(moment());

  constructor() { }

  ngOnInit(): void {
  }

}
