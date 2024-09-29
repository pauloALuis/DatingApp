import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
 
    title = 'DatingApp';
    accountService = inject(AccountService);
  //constructor (private httpClient: HttpClient) {} 
  
      ngOnInit(): void {
     // throw new Error('Method not implemented.');
      this. setCurrentUser();
    }

    setCurrentUser(){

      const userString = localStorage.getItem('user');
      if (!userString)return;
      
      const user = JSON.parse(userString);
      this.accountService.currentUser.set(user);
    }

    
}
