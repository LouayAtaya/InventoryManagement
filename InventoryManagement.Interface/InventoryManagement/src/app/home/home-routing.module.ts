import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from '../shared';
import { AboutusComponent, HomeComponent, SettingsComponent } from './pages';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'settings',component:SettingsComponent},
  {path:'aboutus',component:AboutusComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
