import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {AppSettings} from "../../appsettings";
import {map} from "rxjs/operators";
import {User} from "../Models/User";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private  currentUserSubject : BehaviorSubject<any>;
  public currentUser : Observable<User>;

  constructor(private httpClient: HttpClient) {
    let newUser = localStorage.getItem('currentUser') || '{}';
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(newUser));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(Username: string, Password: string) {
    return this.httpClient.post<any>(AppSettings.BASE_URL + 'Authentication', { Username, Password })
      .pipe(map(user => {
        let newUser: User = user;
        localStorage.setItem('currentUser', JSON.stringify(newUser));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
