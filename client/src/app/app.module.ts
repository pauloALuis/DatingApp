import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,  
    AppRoutingModule, 
    HttpClientModule,
    FormsModule,
     AccordionModule.forRoot(),
     BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
 
  ],
  providers: [ ],
  bootstrap: [AppComponent]
})
export class AppModule { }
