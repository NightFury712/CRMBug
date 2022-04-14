import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaseDatepickerComponent } from './base-datepicker.component';

describe('BaseDatepickerComponent', () => {
  let component: BaseDatepickerComponent;
  let fixture: ComponentFixture<BaseDatepickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaseDatepickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BaseDatepickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
