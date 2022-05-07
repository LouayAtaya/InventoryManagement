import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemCategoryUpdateComponent } from './item-category-update.component';

describe('ItemCategoryUpdateComponent', () => {
  let component: ItemCategoryUpdateComponent;
  let fixture: ComponentFixture<ItemCategoryUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemCategoryUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemCategoryUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
