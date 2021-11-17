import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateplaceComponent } from './createplace.component';

describe('CreateplaceComponent', () => {
  let component: CreateplaceComponent;
  let fixture: ComponentFixture<CreateplaceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateplaceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
