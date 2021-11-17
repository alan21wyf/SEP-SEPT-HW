import { TestBed } from '@angular/core/testing';

import { CabtypeService } from './cabtype.service';

describe('CabtypeService', () => {
  let service: CabtypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CabtypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
