import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemOperationCreateComponent } from './item-operation-create.component';

describe('ItemOperationCreateComponent', () => {
  let component: ItemOperationCreateComponent;
  let fixture: ComponentFixture<ItemOperationCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemOperationCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemOperationCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
