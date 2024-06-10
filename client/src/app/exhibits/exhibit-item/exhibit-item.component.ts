import { Component, Input } from '@angular/core';
import { PlannerService } from 'src/app/planner/planner.service';
import { Exhibit } from 'src/app/shared/models/exhibit';

@Component({
  selector: 'app-exhibit-item',
  templateUrl: './exhibit-item.component.html',
  styleUrls: ['./exhibit-item.component.scss']
})
export class ExhibitItemComponent {
  @Input() exhibit?: Exhibit;

  constructor(private plannerService: PlannerService) {}

  addItemToPlanner(){
    this.exhibit && this.plannerService.addItemToPlanner(this.exhibit);
  }

  

}
