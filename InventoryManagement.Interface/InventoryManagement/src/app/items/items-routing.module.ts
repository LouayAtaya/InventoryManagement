import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemCreateComponent } from './pages/item-create/item-create.component';
import { ItemDetailsComponent } from './pages/item-details/item-details.component';
import { ItemUpdateComponent } from './pages/item-update/item-update.component';
import { ItemsComponent } from './pages/items.component';
import { ItemsListComponent } from './pages/items-list/items-list.component';

const routes: Routes = [
  {path:'', component:ItemsComponent},
  {path:'list', component:ItemsListComponent},
  {path:'add', component:ItemCreateComponent},
  {path:':id', component:ItemDetailsComponent},
  {path:'update/:id', component:ItemUpdateComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemsRoutingModule { }
