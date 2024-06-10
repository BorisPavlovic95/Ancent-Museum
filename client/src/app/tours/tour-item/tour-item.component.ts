import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { TourItem } from 'src/app/shared/models/tour';

@Component({
  selector: 'app-tour-item',
  templateUrl: './tour-item.component.html',
  styleUrls: ['./tour-item.component.scss']
})
export class TourItemComponent {
  @Input() tourItem: TourItem | undefined;


  constructor(private router: Router) { }

  viewTourDetails() {
    if (this.tourItem && this.tourItem.exhibitItemId !== undefined) {
      // Navigate to tour details using the exhibitItemId
     this.router.navigate(['/tour-details', this.tourItem.exhibitItemId]);
    } else {
      console.log('Exhibit item ID is undefined.');
    }
  }
  
}
