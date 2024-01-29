import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
  ],
  templateUrl: './register-form.component.html'
})
export class RegisterFormComponent {
  registerForm!: FormGroup;
  passwordIsNotEqual = false;
  isSubmitting = false;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      repeatPassword: ['', Validators.required],
      phone: ['', Validators.required]
    });
  }

  submitRegister() {
    this.isSubmitting = true;

    if (this.registerForm.valid) {
      if (this.registerForm.value.password !== this.registerForm.value.repeatPassword) {
        this.passwordIsNotEqual = true;
        this.isSubmitting = false;
        return;
      }

      this.passwordIsNotEqual = false;
      this.isSubmitting = false;
      console.log(this.registerForm.value);
      return;
    }

    this.isSubmitting = false;
  }
}
