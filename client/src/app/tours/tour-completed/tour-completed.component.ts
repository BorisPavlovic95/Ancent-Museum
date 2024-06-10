import { Component } from '@angular/core';
import { ToursService } from '../tours.service';
import { Tour } from 'src/app/shared/models/tour';
import { ExhibitsService } from 'src/app/exhibits/exhibits.service';
import { AddRatingCommentDialogComponentComponent } from 'src/app/exhibits/add-rating-comment-dialog-component/add-rating-comment-dialog-component.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-tour-completed',
  templateUrl: './tour-completed.component.html',
  styleUrls: ['./tour-completed.component.scss']
})
export class TourCompletedComponent {
  completedTours: Tour[] = [];
  selectedTourItem: any; 
  constructor(private toursService: ToursService,private dialog: MatDialog, private exhibitService: ExhibitsService) { }

  ngOnInit(): void {
    this.getCompletedTours();
  }

  // getCompletedTours(): void {
  //   this.toursService.getCompletedTours()
  //     .subscribe(
  //       tours => this.completedTours = tours,
  //       error => console.error('Error fetching completed tours:', error)
  //     );
  // }

  fetchTours(): void {
    this.toursService. getCompletedTours().subscribe(
      (response: Tour[]) => {
        this.completedTours = response;
        console.log(response);
      },
      (error) => {
        console.error('Error fetching tours:', error);
      }
    );
  }

  getCompletedTours(): void {
    this.toursService.getCompletedTours()
      .subscribe(tours => this.completedTours = tours);
  }

  getTourProperties(tour: Tour): { name: string, value: string }[] {
    const properties: { name: string, value: string }[] = [];
    for (const [key, value] of Object.entries(tour)) {
      if (typeof value !== 'object') {
        properties.push({ name: key, value: value.toString() });
      }
    }
    return properties;
  }


  tourProperties(tour: Tour): { name: string, value: string }[] {
    const properties: { name: string, value: string }[] = [];
    properties.push({ name: 'First Name', value: tour.userData.firstName });
    properties.push({ name: 'Last Name', value: tour.userData.lastName });
    // Add more properties as needed
    properties.push({ name: 'Tour Status', value: tour.status });
    properties.push({ name: 'Tour Date', value: new Date(tour.tourDate).toLocaleDateString('en-CA') });
    properties.push({ name: 'Subtotal', value: tour.subtotal.toString() });
    return properties;
  }

  // openAddRatingDialog(tourItem: any): void {
  //   const dialogRef = this.dialog.open(AddRatingCommentDialogComponentComponent, {
  //     width: '250px', // Set width as per your design
  //     data: { tourItem: tourItem } // Pass the tour item to the dialog
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     console.log('The dialog was closed');
  //     // Handle any actions after the dialog is closed
  //   });
  // }

  openAddRatingDialog(tour: Tour,tourItem: any): void {
    console.log('Tour item:', tourItem); // Check if tourItem is defined
    this.dialog.open(AddRatingCommentDialogComponentComponent, {
      data: { tour,tourItem }
    });
  }
  
  
  

  closeDialog(): void {
    this.dialog.closeAll();
  }

  addRatingComment(exhibitId: number, ratingComment: any, tourId: number): void {
    // Assuming ratingComment is an object containing properties like 'comment' and other rating details
    this.exhibitService.addRatingComment(exhibitId, ratingComment,tourId).subscribe(
      response => {
        console.log('Rating and comment added successfully:', response);
        // Handle success
      },
      error => {
        console.error('Failed to add rating and comment:', error);
        // Handle error
      }
    );
  }
  
}
  

