import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { SettingsComponent } from './pages/settings/settings.component';
import { AboutusComponent } from './pages/aboutus/aboutus.component';
import { SharedModule } from '../shared';
import { HomeComponent } from './pages';
import { HomeContentComponent } from './pages/home-content/home-content.component';
import 'node_modules/admin-lte-with-rtl/dist/js/adminlte.js'


@NgModule({
  declarations: [
    HomeComponent,
    SettingsComponent,
    AboutusComponent,
    HomeContentComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
  ]
})
export class HomeModule { }
