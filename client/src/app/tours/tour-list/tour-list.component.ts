import { Component } from '@angular/core';
import { ToursService } from '../tours.service';
import { Tour, TourItem } from 'src/app/shared/models/tour';
import { AccountService } from 'src/app/account/account.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tour-list',
  templateUrl: './tour-list.component.html',
  styleUrls: ['./tour-list.component.scss']
})
export class TourListComponent {
  tours: Tour[] = [];

  constructor(private tourService: ToursService,public accountService: AccountService,
              private http: HttpClient, private toastr: ToastrService  ) { }

  ngOnInit(): void {
    this.fetchTours();
  }

  
  fetchTours(): void {
    this.tourService.getToursForUser().subscribe(
      (response: Tour[]) => {
        this.tours = response;
      },
      (error) => {
        console.error('Error fetching tours:', error);
      }
    );
  }

  reserveTour(tourId: number): void {
    this.tourService.reserveTour(tourId).subscribe({
      next: () => {
        console.log('Tour reserved successfully!');
        // Handle success, if needed
      },
      error: (error) => {
        console.error('Error reserving tour:', error);
        // Handle error, if needed
      }
    });
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


}
