import { Component, OnInit } from '@angular/core';
import { ToursService } from '../tours.service';
import { Tour } from 'src/app/shared/models/tour';

@Component({
  selector: 'app-create-tour',
  templateUrl: './create-tour.component.html',
  styleUrls: ['./create-tour.component.scss']
})
export class CreateTourComponent implements OnInit {
  tour: Tour = {
    id: 0,
   
  
    userData: {
      firstName: '',
      lastName: '',
      phone: '',
      birthday: '',
      favoriteExhibit: '',
      city: ''
    },
    tourItems: [],
    userEmail: '',
    status: '',
    tourDate: new Date(),
    subtotal: 0 

  };

  constructor(private tourService: ToursService) { }

  ngOnInit(): void {
  }

  submitForm(): void {
    // Call the service to create the tour
    this.tourService.createTour(this.tour).subscribe(() => {
      // Redirect or show success message
    }, error => {
      console.error('Error creating tour:', error);
      // Handle error, e.g., show error message to user
    });
  }
}

