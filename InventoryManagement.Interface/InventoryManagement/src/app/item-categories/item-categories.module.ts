import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItemCategoriesRoutingModule } from './item-categories-routing.module';
import { ItemCategoriesComponent } from './pages/item-categories.component';
import { ItemCategoryCreateComponent } from './pages/item-category-create/item-category-create.component';
import { ItemCategoryUpdateComponent } from './pages/item-category-update/item-category-update.component';
import { ItemCategoryDetailsComponent } from './pages/item-category-details/item-category-details.component';
import { SharedModule } from '../shared';


@NgModule({
  declarations: [
    ItemCategoriesComponent,
    ItemCategoryCreateComponent,
    ItemCategoryUpdateComponent,
    ItemCategoryDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ItemCategoriesRoutingModule
  ]
})
export class ItemCategoriesModule { }
