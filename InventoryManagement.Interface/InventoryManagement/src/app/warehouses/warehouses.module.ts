import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehousesRoutingModule } from './warehouses-routing.module';
import { WarehousesComponent } from './pages/warehouses.component';
import { WarehouseDetailsComponent } from './pages/warehouse-details/warehouse-details.component';
import { WarehouseCreateComponent } from './pages/warehouse-create/warehouse-create.component';
import { WarehouseUpdateComponent } from './pages/warehouse-update/warehouse-update.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    WarehousesComponent,
    WarehouseDetailsComponent,
    WarehouseCreateComponent,
    WarehouseUpdateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    WarehousesRoutingModule
  ]
})
export class WarehousesModule { }
