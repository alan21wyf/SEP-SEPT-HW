import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatecabtypeComponent } from './updatecabtype.component';

describe('UpdatecabtypeComponent', () => {
  let component: UpdatecabtypeComponent;
  let fixture: ComponentFixture<UpdatecabtypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatecabtypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatecabtypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
