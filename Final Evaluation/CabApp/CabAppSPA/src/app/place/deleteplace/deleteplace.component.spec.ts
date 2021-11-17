import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteplaceComponent } from './deleteplace.component';

describe('DeleteplaceComponent', () => {
  let component: DeleteplaceComponent;
  let fixture: ComponentFixture<DeleteplaceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteplaceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
