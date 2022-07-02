import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent, NotFoundComponent } from './shared';
import { HomeComponent } from './home/pages/home.component';

const routes: Routes = [
  {path: '',  loadChildren: () => import('./home').then(m => m.HomeModule)},
  {path:"login",component:LoginComponent},
  {path:"404",component:NotFoundComponent},
  {path:"**",redirectTo:'404', pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
