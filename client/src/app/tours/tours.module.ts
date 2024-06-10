import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TourListComponent } from './tour-list/tour-list.component';
import { TourDetailsComponent } from './tour-details/tour-details.component';
import { CreateTourComponent } from './create-tour/create-tour.component';
import { EditTourComponent } from './edit-tour/edit-tour.component';
import { TourItemComponent } from './tour-item/tour-item.component';
import { SharedModule } from '../shared/shared.module';
import { ToursRoutingModule } from './tours-routing.module';
import { FormsModule } from '@angular/forms';
import { TourCompletedComponent } from './tour-completed/tour-completed.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule } from '@angular/material/input'
import {MatButtonModule} from '@angular/material/button';
import { ExhibitsModule } from '../exhibits/exhibits.module';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    TourListComponent,
    TourDetailsComponent,
    CreateTourComponent,
    EditTourComponent,
    TourItemComponent,
    TourCompletedComponent

  ],
  imports: [
    CommonModule,
    SharedModule,
    ToursRoutingModule,
    FormsModule,
    MatDialogModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ExhibitsModule,
    MatDatepickerModule,
    MatNativeDateModule
]})
export class ToursModule { }
