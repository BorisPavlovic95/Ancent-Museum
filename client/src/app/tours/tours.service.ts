import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Tour, TourToCreate } from '../shared/models/tour';

@Injectable({
  providedIn: 'root'
})
export class ToursService {

  private baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  // Method to create a new tour
  createTour(tourDto: any): Observable<TourToCreate> {
    return this.http.post<Tour>(`${this.baseUrl}tours`, tourDto);
  }

  // Method to fetch all tours for the current user
  getToursForUser(): Observable<Tour[]> {
    return this.http.get<Tour[]>(`${this.baseUrl}tours`);
  }

  // Method to fetch a single tour by its ID
  getTourByIdForUser(id: number): Observable<Tour> {
    return this.http.get<Tour>(this.baseUrl + 'tours/' + id);
  }

  updateTour(tour: Tour): Observable<Tour> {
    const url = `${this.baseUrl}tours/${tour.id}`; // Construct the URL for the specific tour
    return this.http.put<Tour>(url, tour)
      .pipe(
        catchError(error => {
          console.error('Error updating tour:', error);
          return throwError(error);
        })
      );
    }

  
    reserveTour(tourId: number): Observable<any> {
      return this.http.put(`${this.baseUrl}tours/${tourId}/complete`, {});
    } 
    // getCompletedTours(): Observable<Tour[]> {
    //   return this.http.get<Tour[]>(`${this.baseUrl}tours/completed`);
    // } 
    getCompletedTours(): Observable<Tour[]> {
      return this.http.get<Tour[]>(`${this.baseUrl}tours/completed`);
    }

    updateTourDate(id: number, tourDate: Date): Observable<any> {
      return this.http.put(`${this.baseUrl}tours/${id}/updateTourDate`, { tourDate });
    }
}
