import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabtypeCardComponent } from './cabtype-card.component';

describe('CabtypeCardComponent', () => {
  let component: CabtypeCardComponent;
  let fixture: ComponentFixture<CabtypeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabtypeCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabtypeCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
