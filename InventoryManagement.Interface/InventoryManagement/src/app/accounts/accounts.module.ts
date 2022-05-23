import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsRoutingModule } from './accounts-routing.module';
import { SharedModule } from '../shared';
import { AccountsComponent } from './pages';
import { AccountCreateComponent } from './pages/account-create/account-create.component';
import { AccountDetailsComponent } from './pages/account-details/account-details.component';
import { AccountUpdateComponent } from './pages/account-update/account-update.component';


@NgModule({
  declarations: [
    AccountsComponent,
    AccountCreateComponent,
    AccountDetailsComponent,
    AccountUpdateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AccountsRoutingModule
  ]
})
export class AccountsModule { }
