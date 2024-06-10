import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'', component: HomeComponent, data:{breadcrumb: 'Home'}},
  {path:'exhibits', loadChildren: () => import('./exhibits/exhibits.module').then(m => m.ExhibitsModule)},
  {path:'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)},
  {path:'planner', loadChildren: () => import('./planner/planner.module').then(m => m.PlannerModule)},
  {path:'tours', loadChildren: () => import('./tours/tours.module').then(m => m.ToursModule)},
  {path:'**', redirectTo: '', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
