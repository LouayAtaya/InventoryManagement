import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsService } from './services/items.service';
import { ItemCategoriesService, WarehousesService ,AccountsService,SaleOrdersService,ContentHeaderService,ItemOperationsService} from './services';
import { SharedModule } from '../shared';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [],
  providers:[
    ItemsService,WarehousesService,ItemCategoriesService,AccountsService,SaleOrdersService,ItemOperationsService,ContentHeaderService
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
