import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Subscriber } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggedId= false;
  constructor(private accountService: AccountService) {
    //super();

  }
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
  }
  login(){

    this.accountService.login(this.model ).subscribe({
      next: response => { 
        console.log(response);
        this.loggedId = true;
      
      },
      error: error=> console.log(error)
    });
    console.log(this.model);
    
  }
}
