import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ExhibitsComponent } from './exhibits.component';
import { ExhibitDetailsComponent } from './exhibit-details/exhibit-details.component';
import { ExhibitCommentsComponent } from './exhibit-comments/exhibit-comments.component';

const routes: Routes = [
  { path: '', component: ExhibitsComponent },
  { path:':id', component: ExhibitDetailsComponent, data: {breadcrumb: {alias: 'exhibitDetails'}}},
  { path: ':id/comments', component: ExhibitCommentsComponent } 
];

@NgModule({
  declarations: [],
  imports: [
    // CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ExhibitsRoutingModule { }
