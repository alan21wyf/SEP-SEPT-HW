import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatebookinghistoryComponent } from './createbookinghistory.component';

describe('CreatebookinghistoryComponent', () => {
  let component: CreatebookinghistoryComponent;
  let fixture: ComponentFixture<CreatebookinghistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatebookinghistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatebookinghistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
