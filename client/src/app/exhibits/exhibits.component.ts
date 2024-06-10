import { Component, ElementRef, ViewChild } from '@angular/core';
import { ExhibitsService } from './exhibits.service';
import { Exhibit } from '../shared/models/exhibit';
import { Culture } from '../shared/models/culture';
import { Type } from '../shared/models/type';
import { ExhibitParams } from '../shared/models/exhibitParams';

@Component({
  selector: 'app-exhibits',
  templateUrl: './exhibits.component.html',
  styleUrls: ['./exhibits.component.scss']
})
export class ExhibitsComponent {
  @ViewChild('search') searchTerm?: ElementRef;
  exhibits: Exhibit[] = [];
  cultures: Culture[] = [];
  types: Type[] = [];
  exhibitParams = new ExhibitParams();
  sortOptions = [
    {name: 'Alphabetical', value:'name'},
    {name: 'Price: Low to high', value:'priceAsc'},
    {name: 'Price: High to low', value:'priceDesc'}
  ];
  totalCount = 0;

  constructor(private exhibitService: ExhibitsService) {}
  
  ngOnInit(): void {
    this.getExhibits();
    this.getCultures();
    this.getTypes();
  }

  getExhibits(){
    this.exhibitService.getExhibits(this.exhibitParams).subscribe({
      next: response =>
      { this.exhibits = response.data;
        this.exhibitParams.pageIndex = response.pageIndex;
        this.exhibitParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    })
  }

  getCultures(){
    this.exhibitService.getCultures().subscribe({
      next: response => this.cultures = [{id:0, name:'All'}, ... response],
      error: error => console.log(error)
    })
  }

  getTypes(){
    this.exhibitService.getTypes().subscribe({
      next: response => this.types =  [{id:0, name:'All'}, ... response],
      error: error => console.log(error)
    })
  }

  onCultureSelected(cultureId: number){
    this.exhibitParams.cultureId = cultureId;
    this.exhibitParams.pageIndex = 1;
    this.getExhibits();
  }

  onTypeSelected(typeId: number){
    this.exhibitParams.typeId = typeId;
    this.exhibitParams.pageIndex = 1;
    this.getExhibits();
  }

  onSortSelected(event: any){
    this.exhibitParams.sort = event.target.value;
    this.getExhibits();
  }

  onPageChanged(event: any){
    if(this.exhibitParams.pageIndex !== event){
      this.exhibitParams.pageIndex = event;
      this.getExhibits();
    }
  }

  onSearch(){
    this.exhibitParams.search = this.searchTerm?.nativeElement.value;
    this.exhibitParams.pageIndex = 1;
    this.getExhibits();
  }

  onReset(){
    if(this.searchTerm) this.searchTerm.nativeElement.value = ''
    this.exhibitParams = new ExhibitParams();
    this.getExhibits();
  }
}
