export interface ExhibitRatingComment {
    id: number;
    exhibitId: number;
    userId: string;
    rating: number;
    comment: string;
  }
export interface CommentsDto{
  userId: string;
  rating: number;
  comment: string;
}  