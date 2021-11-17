import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabtypeBookingComponent } from './cabtype-booking.component';

describe('CabtypeBookingComponent', () => {
  let component: CabtypeBookingComponent;
  let fixture: ComponentFixture<CabtypeBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabtypeBookingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabtypeBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
