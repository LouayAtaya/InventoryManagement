import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '../shared';
import { AboutusComponent, HomeComponent, HomeContentComponent, SettingsComponent } from './pages';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      {path:'', redirectTo:'home', pathMatch:'full'},
      { path: 'home', component: HomeContentComponent },
      { path: 'settings', component: SettingsComponent },
      { path: 'aboutus', component: AboutusComponent },
      {path: "warehouses", loadChildren: () => import('src/app/warehouses').then(m => m.WarehousesModule)},
      {path: "items", loadChildren: () => import('src/app/items').then(m => m.ItemsModule)},
      {path: "itemCategories", loadChildren: () => import('src/app/item-categories').then(m => m.ItemCategoriesModule)},
      {path: "saleOrders", loadChildren: () => import('src/app/sale-orders').then(m => m.SaleOrdersModule)},
      {path: "accounts", loadChildren: () => import('src/app/accounts').then(m => m.AccountsModule)},

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
