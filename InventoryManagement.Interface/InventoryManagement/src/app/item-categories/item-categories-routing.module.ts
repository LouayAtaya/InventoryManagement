import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemCategoriesComponent, ItemCategoryCreateComponent, ItemCategoryDetailsComponent, ItemCategoryUpdateComponent } from './pages';

const routes: Routes = [
  {path:'', component:ItemCategoriesComponent},
  {path:'add', component:ItemCategoryCreateComponent},
  {path:':id', component:ItemCategoryDetailsComponent},
  {path:'update/:id', component:ItemCategoryUpdateComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ItemCategoriesRoutingModule { }
