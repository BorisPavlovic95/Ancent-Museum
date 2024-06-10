import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToursService } from '../tours.service';
import { Tour } from 'src/app/shared/models/tour';

@Component({
  selector: 'app-edit-tour',
  templateUrl: './edit-tour.component.html',
  styleUrls: ['./edit-tour.component.scss']
})
export class EditTourComponent {
  tourId?: number;
  tour?: Tour  ;
  newTourDate?: Date; 

  constructor(private route: ActivatedRoute, private tourService: ToursService) { }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      this.tourId = +idParam;
      this.loadTourDetails();
    } else {
      console.error('Tour ID not provided in the route parameter.');
      // Handle the case where the tour ID is not provided in the route parameter
    }
  }

  loadTourDetails(): void {
    if (this.tourId !== undefined) {
      this.tourService.getTourByIdForUser(this.tourId).subscribe(
        (tour: Tour) => {
          this.tour = tour;
          console.log('Tour details loaded:', tour);
        },
        error => {
          console.error('Error loading tour details:', error);
        }
      );
    } else {
      console.error('Tour ID is undefined.');
      // Handle the case where tourId is undefined
    }
  }

 
  updateTour() {
    if (!this.tour) {
      console.error('Tour is undefined');
      return;
    }
  
    this.tourService.updateTour(this.tour).subscribe(
      (updatedTour: Tour) => {
        // Handle successful update
      },
      error => {
        console.log('Error updating tour:', error);
      }
    );
  }

  updateTourDate(id: number, tourDate?: Date): void {
    if (id !== undefined && tourDate !== undefined) {
      this.tourService.updateTourDate(id, tourDate).subscribe(
        () => {
          console.log('Tour date updated successfully');
        },
        (error) => {
          console.error('Failed to update tour date:', error);
        }
      );
    } else {
      console.error('Tour ID or new tour date is undefined');
    }
  }
  
  
  }
  
  

