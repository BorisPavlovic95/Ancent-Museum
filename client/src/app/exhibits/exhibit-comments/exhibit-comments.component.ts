import { Component, Input, OnInit } from '@angular/core';
import { ExhibitsService } from '../exhibits.service';
import { CommentsDto, ExhibitRatingComment } from 'src/app/shared/models/exhibitRatingComment';
import { Exhibit } from 'src/app/shared/models/exhibit';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-exhibit-comments',
  templateUrl: './exhibit-comments.component.html',
  styleUrls: ['./exhibit-comments.component.scss']
})
export class ExhibitCommentsComponent implements OnInit{
  @Input() exhibitId?: number; // Input property to receive exhibit ID from parent component
  comments: CommentsDto[] = []; // Array to store comments

  constructor(private exhibitsService: ExhibitsService) {}

  ngOnInit(): void {
    if (!this.exhibitId) {
      console.error('Exhibit ID is required.');
      return;
    }

    this.exhibitsService.getCommentsByExhibitId(this.exhibitId).subscribe(
      (comments: CommentsDto[]) => {
        this.comments = comments;
      },
      error => {
        console.error('Error fetching comments:', error); // Log any errors during fetching
      }
    );
  }

  
  // loadComments(): void {
  //   this.exhibitsService.getExhibitRatingsComments(this.exhibitId!).subscribe(
  //     comments => {
  //       this.comments = comments;
  //     },
  //     error => {
  //       console.error('Error fetching comments:', error);
  //     }
  //   );
  // }

  
  }
