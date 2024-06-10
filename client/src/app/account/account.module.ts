import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { SharedModule } from '../shared/shared.module';
import { EditAccountComponent } from './edit-account/edit-account.component';

import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [LoginComponent,
                RegisterComponent,
                EditAccountComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class AccountModule { }
