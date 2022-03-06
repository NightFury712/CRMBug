import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
  priorities = [
    {
      value: '1',
      valueText: 'Hello'
    },
    {
      value: '2',
      valueText: 'Hi'
    },
    {
      value: '3',
      valueText: 'Good'
    }
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
