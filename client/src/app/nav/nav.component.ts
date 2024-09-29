import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { NgIf } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, NgIf, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',

})
export class NavComponent {
  accountServices = inject(AccountService);
  //loggedIn = false;
  model: any= {};

  login(){
  console.log(this.model);
  this.accountServices.login(this.model).subscribe({
    next: response => {

      console.log(response);
      //this.loggedIn = true;
    },
    error: error=> console.log( error)
    
  });
  }


  logout(){
  //console.log(this.model);
  this.accountServices.logout();
  }
}