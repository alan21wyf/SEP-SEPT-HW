import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingsInfoComponent } from './bookings-info.component';

describe('BookingsInfoComponent', () => {
  let component: BookingsInfoComponent;
  let fixture: ComponentFixture<BookingsInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingsInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingsInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
