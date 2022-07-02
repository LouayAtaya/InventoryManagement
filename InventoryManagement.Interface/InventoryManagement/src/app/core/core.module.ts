import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsService } from './services/items.service';
import { ItemCategoriesService, WarehousesService ,AccountsService,SaleOrdersService,ContentHeaderService,ItemOperationsService} from './services';
import { SharedModule } from '../shared';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppHttpInterceptor } from './interceptors/app-http.interceptor';
import { UsersService } from './services/users.service';



@NgModule({
  declarations: [],
  providers:[
    ItemsService,
    WarehousesService,ItemCategoriesService,
    AccountsService,
    SaleOrdersService,
    ItemOperationsService,
    ContentHeaderService,
    UsersService,
    {provide:HTTP_INTERCEPTORS,useClass: AppHttpInterceptor, multi:true}
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class CoreModule { 
  constructor(@Optional() @SkipSelf() core:CoreModule ){
    if (core) {
        throw new Error("You should import core module only in the root module")
    }
  }
}
