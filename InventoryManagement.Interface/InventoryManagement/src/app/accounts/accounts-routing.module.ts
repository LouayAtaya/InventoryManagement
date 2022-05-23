import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountCreateComponent } from './pages';
import { AccountsComponent } from './pages/accounts.component';
import { AccountDetailsComponent } from './pages/account-details/account-details.component';
import { AccountUpdateComponent } from './pages/account-update/account-update.component';

const routes: Routes = [
  {path:'', component:AccountsComponent},
  {path:'add', component:AccountCreateComponent},
  {path:':id', component:AccountDetailsComponent},
  {path:'update/:id', component:AccountUpdateComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsRoutingModule { }
