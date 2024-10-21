import { Component, EventEmitter, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  usersFormHomeComponent= input.required<any>();
  cancelRegister = output<boolean>();
  model: any= {}

  register(){
    console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log("Test register: " );
        console.log( response);

                         this.cancel();
      },
      error: error => console.log("Test register: " +error)
      
    })
  
      console.log("Test: --- " );
      console.log(this.model);
  }


  cancel(){
    console.log("Cancelled");
    this.cancelRegister.emit(false);
  }
}
