import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletecabtypeComponent } from './deletecabtype.component';

describe('DeletecabtypeComponent', () => {
  let component: DeletecabtypeComponent;
  let fixture: ComponentFixture<DeletecabtypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletecabtypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletecabtypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
