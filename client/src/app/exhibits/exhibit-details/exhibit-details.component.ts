import { Component } from '@angular/core';
import { Exhibit } from 'src/app/shared/models/exhibit';
import { ExhibitsService } from '../exhibits.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { CommentsDto } from 'src/app/shared/models/exhibitRatingComment';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-exhibit-details',
  templateUrl: './exhibit-details.component.html',
  styleUrls: ['./exhibit-details.component.scss']
})
export class ExhibitDetailsComponent {
  exhibit?: any;
  comments$?: Observable<CommentsDto[]>
 

  constructor(private exhibitService: ExhibitsService, private activatedRoute: ActivatedRoute, 
    private bcService: BreadcrumbService,private router: Router) {
      this.bcService.set('@exhibitDetails', ' ')
    }
  ngOnInit(): void {
    this.loadExhibit();
  }

  loadExhibit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
  
    if (!id || isNaN(+id)) {
      console.error('Invalid Exhibit ID:', id);
      this.router.navigate(['/default-page']);
      return;
    }

    this.exhibitService.getExhibit(+id).subscribe({
      next: exhibit => {
        if (!exhibit) {
          console.error('Exhibit not found for ID:', id);
          this.router.navigate(['/default-page']);
          return;
        }
        this.exhibit = exhibit;

        // Once exhibit is loaded, fetch comments
        this.fetchComments(+id);
      },
      error: error => {
        console.error('Error fetching exhibit:', error);
        this.router.navigate(['/default-page']);
      }
    });
  }

  fetchComments(exhibitId: number) {
    this.comments$ = this.exhibitService.getCommentsByExhibitId(exhibitId);
  }

  getStarRating(rating: number): string {
    const stars = '★'.repeat(rating) + '☆'.repeat(5 - rating);
    return stars;
  }
  
  }