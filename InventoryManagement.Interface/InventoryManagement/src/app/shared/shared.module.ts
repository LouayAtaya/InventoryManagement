import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, NG_VALIDATORS, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ContentHeaderComponent, FooterComponent, LoginComponent, MainHeaderComponent, MainSidebarComponent, PreloaderComponent } from './layout';
import { NotFoundComponent } from './layout/not-found/not-found.component';
import { NotEmptyValidatorDirective } from './directives/not-empty.validator';



@NgModule({
  declarations: [
    FooterComponent,
    PreloaderComponent,
    MainHeaderComponent,
    MainSidebarComponent,
    ContentHeaderComponent,
    NotFoundComponent,
    NotEmptyValidatorDirective,
    LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
  ],
  
  exports:[
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    PreloaderComponent,MainHeaderComponent,MainSidebarComponent,ContentHeaderComponent,FooterComponent,NotFoundComponent,NotEmptyValidatorDirective

  ]
})
export class SharedModule { }
