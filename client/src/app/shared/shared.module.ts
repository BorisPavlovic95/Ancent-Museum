import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextComponent } from './input-text/input-text.component';
import { PagerComponent } from './pager/pager.component';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    InputTextComponent,
    PagerComponent,
    PagingHeaderComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    RouterModule
  ],
  exports:[
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule,
    ReactiveFormsModule,
    BsDropdownModule,
    InputTextComponent
  ]
})
export class SharedModule { }
