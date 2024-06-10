import { Component } from '@angular/core';
import { AccountService } from './account/account.service';
import { PlannerService } from './planner/planner.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Ancent museum';

  constructor(private accountService: AccountService,private plannerService: PlannerService){}

  ngOnInit(): void {
    this.loadCurrentUser();
    const plannerId = localStorage.getItem('planner_id');
    if (plannerId) this.plannerService.getPlanner(plannerId);
  }

  loadCurrentUser(){
    const token = localStorage.getItem('token');
    if(token) this.accountService.loadCurrentUser(token).subscribe();
  }
}
