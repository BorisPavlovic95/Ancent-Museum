import { Component } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { PlannerService } from 'src/app/planner/planner.service';
import { PlannerItem } from 'src/app/shared/models/planner';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  constructor( public accountService: AccountService, public plannerService: PlannerService){}

  
}
