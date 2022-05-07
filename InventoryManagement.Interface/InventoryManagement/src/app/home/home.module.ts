import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { AboutusComponent } from './pages/aboutus/aboutus.component';
import { SharedModule } from '../shared';


@NgModule({
  declarations: [
    HomeComponent,
    SettingsComponent,
    AboutusComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
