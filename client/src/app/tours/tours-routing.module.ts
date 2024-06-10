import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TourListComponent } from './tour-list/tour-list.component';
import { TourDetailsComponent } from './tour-details/tour-details.component';
import { CreateTourComponent } from './create-tour/create-tour.component';
import { EditTourComponent } from './edit-tour/edit-tour.component';
import { TourItemComponent } from './tour-item/tour-item.component';
import { TourCompletedComponent } from './tour-completed/tour-completed.component';

const routes: Routes = [
  { path: 'createTour', component: TourListComponent },
  { path:'completed', component: TourCompletedComponent, data: {breadcrumb: {alias: 'tourItem'}}},
  { path:':id', component: TourDetailsComponent, data: {breadcrumb: {alias: 'tourDetails'}}},
  { path:'', component: CreateTourComponent, data: {breadcrumb: {alias: 'createTour'}}},
  { path:'editTour/:id', component: EditTourComponent, data: {breadcrumb: {alias: 'editTour'}}},
  { path:':tourItem', component: TourItemComponent, data: {breadcrumb: {alias: 'tourItem'}}},

];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ToursRoutingModule { }
