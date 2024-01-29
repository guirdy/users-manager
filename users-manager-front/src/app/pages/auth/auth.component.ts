import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormComponent } from '../../components/login-form/login-form.component';
import { RegisterFormComponent } from '../../components/register-form/register-form.component';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [CommonModule, LoginFormComponent, RegisterFormComponent],
  templateUrl: './auth.component.html'
})
export class AuthComponent {
  loginSelected = true;
  registerSelected = false;

  constructor() {}

  onClickLoginMenu() {
    this.loginSelected = true;
    this.registerSelected = false;
  }

  onClickRegisterMenu() {
    this.loginSelected = false;
    this.registerSelected = true;
  }
}
