import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaleOrderCreateComponent, SaleOrderDetailsComponent, SaleOrderUpdateComponent } from './pages';
import { SaleOrdersComponent } from './pages/sale-orders.component';

const routes: Routes = [
  {path:'', component:SaleOrdersComponent},
  {path:'add', component:SaleOrderCreateComponent},
  {path:':id', component:SaleOrderDetailsComponent},
  {path:'update/:id', component:SaleOrderUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaleOrdersRoutingModule { }
