import { Component, Inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ExhibitsService } from '../exhibits.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Tour } from 'src/app/shared/models/tour';


@Component({
  selector: 'app-add-rating-comment-dialog-component',
  templateUrl: './add-rating-comment-dialog-component.component.html',
  styleUrls: ['./add-rating-comment-dialog-component.component.scss']
})
export class AddRatingCommentDialogComponentComponent {
  @Input() tourItem: any;
  @Input() tour?: Tour;
  ratingForm: FormGroup;
  selectedStars: number = 0;
  //exhibit?: any;
  stars = [
    { value: 1, label: '1 Star' },
    { value: 2, label: '2 Stars' },
    { value: 3, label: '3 Stars' },
    { value: 4, label: '4 Stars' },
    { value: 5, label: '5 Stars' }
  ];

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddRatingCommentDialogComponentComponent>,
    public exhibitService: ExhibitsService,
    //private activatedRoute: ActivatedRoute,
    //private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    console.log('Dialog data:', data);
    this.ratingForm = new FormGroup({
      rating: new FormControl('', Validators.required),
      comment: new FormControl('', Validators.required)
    });
  }
  // ngOnInit(): void {
  //   this.loadExhibit();
  // }
  /* openDialog(exhibitItemId: number): void {
    // Assuming you have a dialog service to open the dialog
    this.openDialog(exhibitItemId);
  } */

  submitRating(): void {
    if (this.data && this.data.tourItem && this.data.tourItem.exhibitId && this.selectedStars) {
        const exhibitId = this.data.tourItem.exhibitId;
        const tourId = this.data.tour?.id; // Assuming this.tour is the tour object containing the id
        const ratingComment = {
            exhibitId: exhibitId,
            rating: this.selectedStars,
            comment: this.ratingForm.value.comment
        };
        // Add null check for tourId
        if (tourId !== undefined) {
            this.addRatingComment(exhibitId, ratingComment, tourId);
            this.dialogRef.close();
        } else {
            console.error('Tour ID is undefined.');
            // Handle the case when tourId is undefined
        }
    }
}

  

  closeDialog(): void {
    this.dialogRef.close();
  }

  addRatingComment(exhibitId: number, ratingComment: any, tourId: number): void {
    // Assuming ratingComment is an object containing properties like 'comment' and other rating details
    this.exhibitService.addRatingComment(exhibitId, ratingComment, tourId).subscribe(
      response => {
        console.log('Rating and comment added successfully:', response);
        // Handle success
      },
      error => {
        console.error('Failed to add rating and comment:', error);
        // Handle error
      }
    );
  }

  // loadExhibit() {
  //   const id = this.activatedRoute.snapshot.paramMap.get('id');
  
  //   if (!id || isNaN(+id)) {
  //     console.error('Invalid Exhibit ID:', id);
  //     this.router.navigate(['/default-page']);
  //     return;
  //   }

  //   this.exhibitService.getExhibit(+id).subscribe({
  //     next: exhibit => {
  //       if (!exhibit) {
  //         console.error('Exhibit not found for ID:', id);
  //         this.router.navigate(['/default-page']);
  //         return;
  //       }
  //       this.exhibit = exhibit;

  //       // Once exhibit is loaded, fetch comments
  //       //this.fetchComments(+id);
  //     },
  //     error: error => {
  //       console.error('Error fetching exhibit:', error);
  //       this.router.navigate(['/default-page']);
  //     }
  //   });
  // }
}

