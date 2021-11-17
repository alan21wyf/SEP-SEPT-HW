import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabtypeBookinghistoryComponent } from './cabtype-bookinghistory.component';

describe('CabtypeBookinghistoryComponent', () => {
  let component: CabtypeBookinghistoryComponent;
  let fixture: ComponentFixture<CabtypeBookinghistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabtypeBookinghistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabtypeBookinghistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
