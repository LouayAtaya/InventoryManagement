import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WarehouseCreateComponent, WarehouseDetailsComponent, WarehousesComponent, WarehouseUpdateComponent } from './pages';

const routes: Routes = [
  {path:'', component:WarehousesComponent},
  {path:'add', component:WarehouseCreateComponent},
  {path:':id', component:WarehouseDetailsComponent},
  {path:'update/:id', component:WarehouseUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehousesRoutingModule { }
