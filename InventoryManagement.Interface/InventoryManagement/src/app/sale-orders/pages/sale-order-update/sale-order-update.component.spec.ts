import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaleOrderUpdateComponent } from './sale-order-update.component';

describe('SaleOrderUpdateComponent', () => {
  let component: SaleOrderUpdateComponent;
  let fixture: ComponentFixture<SaleOrderUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaleOrderUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SaleOrderUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
