import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExhibitsComponent } from './exhibits.component';

import { ExhibitDetailsComponent } from './exhibit-details/exhibit-details.component';
import { ExhibitItemComponent } from './exhibit-item/exhibit-item.component';
import { ExhibitsRoutingModule } from './exhibits-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ExhibitCommentsComponent } from './exhibit-comments/exhibit-comments.component';
import { AddRatingCommentDialogComponentComponent } from './add-rating-comment-dialog-component/add-rating-comment-dialog-component.component';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import {MatInputModule } from '@angular/material/input';
//import { StarRatingModule } from 'angular-star-rating';
import { RatingModule } from 'ngx-bootstrap/rating';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ExhibitsComponent,
    ExhibitDetailsComponent,
    ExhibitItemComponent,
    ExhibitCommentsComponent,
    AddRatingCommentDialogComponentComponent
  ],
  imports: [
    CommonModule,
    ExhibitsRoutingModule,
    SharedModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    RatingModule.forRoot(),
    //StarRatingModule.forRoot()
    FormsModule
  ],
  exports: [AddRatingCommentDialogComponentComponent]
})
export class ExhibitsModule { }
