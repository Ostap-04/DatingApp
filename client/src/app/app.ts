import {Component, inject, OnInit, signal} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {lastValueFrom} from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private http = inject(HttpClient);  // constructor(private http: HttpClient) {}
  protected readonly title = signal('Dating app');
  protected members = signal<any>([])

  async ngOnInit() {
    this.members.set(await this.getMembers());
  }

  async getMembers() {
    try {
      return lastValueFrom(this.http.get('https://localhost:5001/members'))
    } catch (err) {
      console.log(err);
      throw err;
    }
  }
}
