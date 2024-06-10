import { Component } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  errors: string[] | null = null;
  complexPassword = "(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";

  // Define the address form group
  addressForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    phone: [''],
    birthday: [''],
    favoriteExhibit: [''],
    city: ['']
  });

  // Extend the main registration form group
  registerForm = this.fb.group({
    displayName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.pattern(this.complexPassword)]],
    address: this.addressForm
  });

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {}

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => this.router.navigateByUrl('/shop'),
      error: error => this.errors = error.errors
    });
  }
}
