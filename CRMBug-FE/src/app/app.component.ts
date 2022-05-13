import { DataService } from './service/data/data.service';
import { take, map } from 'rxjs/operators';
import { AuthService } from './service/auth/auth.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BugTracking';
  isLogin = false;
  /**
   * Constructor
   */
  constructor(
    private authSV : AuthService,
    private dataSV: DataService
  ) {
    this.dataSV.user.subscribe(user => {
      if(user) {
        this.isLogin = true;
      }
    })
    
  }
}
