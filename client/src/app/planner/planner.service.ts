import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Planner, PlannerItem } from '../shared/models/planner';
import { HttpClient } from '@angular/common/http';
import { Exhibit } from '../shared/models/exhibit';
import { ToastrService } from 'ngx-toastr';
import { ToursService } from '../tours/tours.service';
import { AccountService } from '../account/account.service';
import { Address } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class PlannerService {
  baseUrl = 'https://localhost:5001/api/';
  private plannerSource = new BehaviorSubject<Planner | null>(null);
  plannerSource$ = this.plannerSource.asObservable();

  constructor(private http: HttpClient, private toastr: ToastrService, private tourService: ToursService,private account: AccountService) { }

  getPlanner(id: string){
    return this.http.get<Planner>(this.baseUrl + 'planner?id=' + id).subscribe({
      next: planner => this.plannerSource.next(planner)
    })
  }

  setPlanner(planner: Planner){
    return this.http.post<Planner>(this.baseUrl + 'planner', planner).subscribe({
      next: planner => {
      this.plannerSource.next(planner)
      }
    })
  }

  getCurrentPlannerValue(){
    return this.plannerSource.value;
  }

  addItemToPlanner(item: Exhibit) {
    const itemToAdd = this.mapExhibitItemToPlannerItem(item);
    const planner = this.getCurrentPlannerValue() ?? this.createPlanner();
    planner.items = this.addOrUpdateItem(planner.items, itemToAdd);
    this.setPlanner(planner);
  }
  addOrUpdateItem(items: PlannerItem[], itemToAdd: PlannerItem): PlannerItem[] {
    const index = items.findIndex(x => x.id === itemToAdd.id);
  
    if (index !== -1) {
      // If the item exists, update it
      items[index] = itemToAdd;
    } else {
      // If the item doesn't exist, add it
      items.push(itemToAdd);
    }
  
    return items;
  }
  createPlanner(): Planner  {
    const planner = new Planner();
    localStorage.setItem('planner_id', planner.id);
    return planner;
  }

  private mapExhibitItemToPlannerItem(item: Exhibit) : PlannerItem{
    return {
      id: item.id,
      exhibitName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      type: item.exhibitType
    }
  }
  deleteItemFromPlanner(itemId: number): void {
    const planner = this.getCurrentPlannerValue();
    
    if (planner) {
      planner.items = planner.items.filter(item => item.id !== itemId);
      this.setPlanner(planner);
    }
  }

  


        
  
}
