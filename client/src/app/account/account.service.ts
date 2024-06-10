import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { Address, User } from '../shared/models/user';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AddressDto } from '../shared/models/userProfile';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/api/";
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  login(values: any){
    return this.http.post<User>(this.baseUrl + 'account/login', values).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      })
    )
  }

  register(values: any){
    return this.http.post<User>(this.baseUrl + 'account/register', values).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      })
    )
  }

  logout(){
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string){
    return this.http.get<boolean>(this.baseUrl + 'account/emailExists?email=' + email);
  }

  loadCurrentUser(token: string){
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get<User>(this.baseUrl + 'account', {headers}).pipe(
      map(user => {
        localStorage.setItem('token', user.token);
        this.currentUserSource.next(user);
      })
    )
  }

  returnUserAddress(): Observable<AddressDto> {
    return this.http.get<AddressDto>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: Address){
    return this.http.put(this.baseUrl + 'account/address', address);
  }
}
