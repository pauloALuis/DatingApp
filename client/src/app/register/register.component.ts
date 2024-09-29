import { Component, EventEmitter, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
 usersFormHomeComponent= input.required<any>();
 cancelRegister = output<boolean>();
  model: any= {}

  register(){
    console.log(this.model);
  
  }


  cancel(){
    console.log(this.model);
    console.log("Cancelled");
    this.cancelRegister.emit(false);
  }
}
