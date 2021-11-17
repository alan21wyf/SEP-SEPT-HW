import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingshistoryInfoComponent } from './bookingshistory-info.component';

describe('BookingshistoryInfoComponent', () => {
  let component: BookingshistoryInfoComponent;
  let fixture: ComponentFixture<BookingshistoryInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingshistoryInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingshistoryInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
