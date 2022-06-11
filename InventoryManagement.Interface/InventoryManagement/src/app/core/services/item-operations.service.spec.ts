import { TestBed } from '@angular/core/testing';

import { ItemOperationsService } from './item-operations.service';

describe('ItemOperationsService', () => {
  let service: ItemOperationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItemOperationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
