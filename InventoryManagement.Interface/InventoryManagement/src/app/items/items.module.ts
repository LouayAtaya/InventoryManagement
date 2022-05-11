import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ItemsRoutingModule } from './items-routing.module';
import { ItemsComponent } from './pages/items.component';
import { ItemCreateComponent } from './pages/item-create/item-create.component';
import { ItemUpdateComponent } from './pages/item-update/item-update.component';
import { ItemDetailsComponent } from './pages/item-details/item-details.component';
import { SharedModule } from '../shared/shared.module';
import { ItemsListComponent } from './pages/items-list/items-list.component';


@NgModule({
  declarations: [
    ItemsComponent,
    ItemCreateComponent,
    ItemUpdateComponent,
    ItemDetailsComponent,
    ItemsListComponent
  ],
  imports: [
    CommonModule,
    ItemsRoutingModule,
    SharedModule
  ]
})
export class ItemsModule { }
