import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletebookinghistoryComponent } from './deletebookinghistory.component';

describe('DeletebookinghistoryComponent', () => {
  let component: DeletebookinghistoryComponent;
  let fixture: ComponentFixture<DeletebookinghistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletebookinghistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletebookinghistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
