import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent {
  isLoading = false;
  error: string = '';
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  /**
   * Handle sự kiện form submit
   */
  submit(e: any) {
    this.isLoading = true;

    //Gọi api login từ service
    this.authService.login(this.username, this.password).subscribe(
      (resp) => {
        if (!resp.Success) {
          this.error = resp['userMsg'];
        } else {
          this.router.navigate(['/dashboard']);
        }
        this.isLoading = false;
      },
      (error) => {
        console.log(error);
        this.error = error;
        this.isLoading = false;
      }
    );
  }

  toRegister(e: any) {
    this.router.navigate(['/register']);
  }
}
