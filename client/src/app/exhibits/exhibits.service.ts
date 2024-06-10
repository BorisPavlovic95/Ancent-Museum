import { Injectable } from '@angular/core';
import { ExhibitParams } from '../shared/models/exhibitParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Pagination } from '../shared/models/pagination';
import { Exhibit } from '../shared/models/exhibit';
import { Culture } from '../shared/models/culture';
import { Type } from '../shared/models/type';
import { CommentsDto, ExhibitRatingComment } from '../shared/models/exhibitRatingComment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExhibitsService {

  baseUrl = 'https://localhost:5001/api/';
  constructor(private http:HttpClient) { }

  getExhibits(exhibitParams: ExhibitParams){
      let params = new HttpParams();
      if(exhibitParams.cultureId >0) params = params.append('cultureId', exhibitParams.cultureId);
      if(exhibitParams.typeId) params = params.append('typeId', exhibitParams.typeId);
      params = params.append('sort', exhibitParams.sort);
      params = params.append('pageIndex', exhibitParams.pageIndex);
      params = params.append('pageSize', exhibitParams.pageSize);
      if(exhibitParams.search) params = params.append('search', exhibitParams.search);
    return this.http.get<Pagination<Exhibit[]>>(this.baseUrl + 'exhibits', {params});
  }

  getCultures(){
    return this.http.get<Culture[]>(this.baseUrl + 'exhibits/cultures');
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl + 'exhibits/types');
  }

  getExhibit(id: number){
    return this.http.get<Exhibit>(this.baseUrl + 'exhibits/' + id);
  }

  // getExhibitRatingsComments(tourId: number): Observable<ExhibitRatingComment[]> {
  //   return this.http.get<ExhibitRatingComment[]>(`${this.baseUrl}/ExhibitRatings/${tourId}`);
  // }
  
  getCommentsByExhibitId(exhibitId: number): Observable<CommentsDto[]> {
    return this.http.get<CommentsDto[]>(`${this.baseUrl}exhibitRatings/comment/${exhibitId}`);
  }
  addRatingComment(exhibitId: number, ratingComment: CommentsDto, tourId: number): Observable<CommentsDto> {
    return this.http.post<CommentsDto>(`${this.baseUrl}exhibitRatings/${exhibitId}?tourId=${tourId}`, ratingComment);
  }
  
  
}
