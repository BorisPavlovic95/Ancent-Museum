import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Tour } from 'src/app/shared/models/tour';
import { ToursService } from '../tours.service';

@Component({
  selector: 'app-tour-details',
  templateUrl: './tour-details.component.html',
  styleUrls: ['./tour-details.component.scss']
})
export class TourDetailsComponent {
  //@Input() tour?: Tour;
  tour: Tour | undefined;

  constructor(
    private route: ActivatedRoute,
    private tourService: ToursService,
    private router: Router
  
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.tourService.getTourByIdForUser(id).subscribe(tour => {
        this.tour = tour;
      });
    });
  }

  goToEditTour(id: number) {
    this.router.navigate(['/editTour', id]);
  }

  
}
