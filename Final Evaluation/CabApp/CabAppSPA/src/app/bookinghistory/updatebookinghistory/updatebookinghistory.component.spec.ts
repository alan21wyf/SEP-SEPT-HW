import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatebookinghistoryComponent } from './updatebookinghistory.component';

describe('UpdatebookinghistoryComponent', () => {
  let component: UpdatebookinghistoryComponent;
  let fixture: ComponentFixture<UpdatebookinghistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatebookinghistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatebookinghistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
