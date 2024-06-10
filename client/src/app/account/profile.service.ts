import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from '../shared/models/userProfile';



@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private apiUrl = "https://localhost:5001/api/";

  constructor(private http: HttpClient) { }

  getUserProfile(): Observable<UserProfile> {
    return this.http.get<UserProfile>(`${this.apiUrl}account/current`);
  }

  updateUserProfile(profile: UserProfile): Observable<any> {
    return this.http.put(`${this.apiUrl}account/update-profile`, profile);
  }
}
