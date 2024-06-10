import { Component } from '@angular/core';
import { PlannerService } from './planner.service';
import { Planner, PlannerItem } from '../shared/models/planner';
import { ToursService } from '../tours/tours.service';
import { AccountService } from '../account/account.service';
import { ToastrService } from 'ngx-toastr';
import { Observable, catchError, map, throwError } from 'rxjs';

@Component({
  selector: 'app-planner',
  templateUrl: './planner.component.html',
  styleUrls: ['./planner.component.scss']
})
export class PlannerComponent {
  constructor(public plannerService: PlannerService, private toastr: ToastrService, private tourService: ToursService,private account: AccountService){}

 /* incrementQuantity(item: BasketItem){
    this.plannerService.addItemToBasket(item);

  }  */

  removeItem(item: PlannerItem): void {
    this.plannerService.deleteItemFromPlanner(item.id);
  }
  calculateTotalPrice(items: PlannerItem[]): number {
    return items.reduce((total, item) => total + item.price, 0);
  }

  

  submitTour(): void {
    const planner = this.plannerService.getCurrentPlannerValue();
    if (!planner) return;
  
    this.getTourToCreate(planner).subscribe({
      next: (tourToCreate: any) => {
        if (!tourToCreate) return;
        
        this.tourService.createTour(tourToCreate).subscribe({
          next: (tour) => {
            this.toastr.success('Tour Created successfully');
            console.log('Tour created:', tour);
          },
          error: (error) => {
            console.error('Error creating tour:', error);
            // Handle error
          }
        });
      },
      error: (error) => {
        console.error('Error getting tour to create:', error);
        // Handle error
      }
    });
  }

    private getTourToCreate(planner: Planner): Observable<any> {
      return this.account.returnUserAddress().pipe(
        map((userProfileData: any) => {
          if (!userProfileData) throw new Error('User profile data not available');
    
          const addressDto = this.mapToAddressDto(userProfileData);
          console.log('User profile data:', userProfileData);
    
          return {
            plannerId: planner.id,
            userData: addressDto
          };
        }),
        catchError((error) => {
          console.error('Error fetching user address:', error);
          return throwError(error);
        })
      );
    }
    
    

    private mapToAddressDto(userProfileData: any): any {
      return {
        firstName: userProfileData.firstName,
        lastName: userProfileData.lastName,
        phone: userProfileData.phone,
        birthday: userProfileData.birthday,
        favoriteExhibit: userProfileData.favoriteExhibit,
        city: userProfileData.city
      };
    }
    getUserProfileAddress(): void {
      this.account.returnUserAddress().subscribe({
        next: (addressDto) => {
          // Handle the address data here
          console.log(addressDto);
        },
        error: (error) => {
          // Handle errors
          console.error('Error fetching user address:', error);
        }
      });
    }
 
}
