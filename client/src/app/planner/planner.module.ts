import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { PlannerRoutingModule } from './planner-routing.module';
import { PlannerComponent } from './planner.component';



@NgModule({
  declarations: [PlannerComponent],
  imports: [
    CommonModule,
    SharedModule,
    PlannerRoutingModule,
   
  ]
})
export class PlannerModule { }
