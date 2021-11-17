import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatecabtypeComponent } from './createcabtype.component';

describe('CreatecabtypeComponent', () => {
  let component: CreatecabtypeComponent;
  let fixture: ComponentFixture<CreatecabtypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatecabtypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatecabtypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
