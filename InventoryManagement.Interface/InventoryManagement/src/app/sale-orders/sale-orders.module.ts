import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaleOrdersRoutingModule } from './sale-orders-routing.module';
import { SharedModule } from '../shared';
import { SaleOrdersComponent } from './pages';
import { SaleOrderCreateComponent } from './pages/sale-order-create/sale-order-create.component';
import { SaleOrderUpdateComponent } from './pages/sale-order-update/sale-order-update.component';
import { SaleOrderDetailsComponent } from './pages/sale-order-details/sale-order-details.component';


@NgModule({
  declarations: [
    SaleOrdersComponent,
    SaleOrderCreateComponent,
    SaleOrderUpdateComponent,
    SaleOrderDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    SaleOrdersRoutingModule,
  ]
})
export class SaleOrdersModule { }
