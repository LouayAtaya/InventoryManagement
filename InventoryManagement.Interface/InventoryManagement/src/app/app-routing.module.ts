import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './shared/layout/not-found/not-found.component';

const routes: Routes = [
  {path:'', redirectTo:'home', pathMatch:'full'},
  {path: "home", loadChildren: () => import('./home').then(m => m.HomeModule)},
  {path: "warehouses", loadChildren: () => import('./warehouses').then(m => m.WarehousesModule)},
  {path: "items", loadChildren: () => import('./items').then(m => m.ItemsModule)},
  {path: "itemCategories", loadChildren: () => import('./item-categories').then(m => m.ItemCategoriesModule)},
  {path: "accounts", loadChildren: () => import('./accounts').then(m => m.AccountsModule)},
  {path:"404",component:NotFoundComponent},
  {path:"**",redirectTo:'404'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
