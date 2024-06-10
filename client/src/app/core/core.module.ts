import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NavBarComponent } from './nav-bar/nav-bar.component';




@NgModule({
  declarations: [
    SectionHeaderComponent,
    NavBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    NgxSpinnerModule,
    BreadcrumbModule
  ],
  exports:[
    NavBarComponent,
    SectionHeaderComponent,
    NgxSpinnerModule
  ]
})
export class CoreModule { }
