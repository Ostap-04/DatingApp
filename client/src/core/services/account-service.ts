import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginCredentials, RegisterCredentials, User} from '../../types/user';
import {tap} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null)

  baseUrl = 'https://localhost:5001/';

  register(credentials: RegisterCredentials) {
    return this.http.post<User>(this.baseUrl + 'account/register', credentials).pipe(
      tap({
        next: (user) => {
          this.setCurrentUser(user);
        },
        error: (err) => {
          console.error('Register failed', err);
        }
      })
    );
  }

  login(credentials: LoginCredentials) {
    return this.http.post<User>(this.baseUrl + 'account/login', credentials).pipe(
      tap({
        next: (user) => {
          this.setCurrentUser(user);
        },
        error: (err) => {
          console.error('Login failed', err);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
