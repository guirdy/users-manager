import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
  ],
  templateUrl: './login-form.component.html'
})
export class LoginFormComponent {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  submitLogin() {
    if (this.loginForm.valid) {
      alert(`${this.loginForm.value.email} ${this.loginForm.value.password}`);
      return;
    }
  }
}
