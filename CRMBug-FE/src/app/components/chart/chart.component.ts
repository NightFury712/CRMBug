import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
  priorities = [
    {
      Value: '1',
      Text: 'Hello'
    },
    {
      Value: '2',
      Text: 'Hi'
    },
    {
      Value: '3',
      Text: 'Good'
    }
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
