import { TestBed } from '@angular/core/testing';

import { SaleOrdersService } from './sale-orders.service';

describe('SaleOrdersService', () => {
  let service: SaleOrdersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SaleOrdersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
