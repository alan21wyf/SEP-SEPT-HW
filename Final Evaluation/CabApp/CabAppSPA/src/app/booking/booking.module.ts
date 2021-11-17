import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingRoutingModule } from './booking-routing.module';
import { BookingComponent } from './booking.component';
import { DeletebookingComponent } from './deletebooking/deletebooking.component';
import { CreatebookingComponent } from './createbooking/createbooking.component';
import { UpdatebookingComponent } from './updatebooking/updatebooking.component';
import { BookingsInfoComponent } from '../shared/components/bookings-info/bookings-info.component';
import { AppModule } from '../app.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BookingComponent,
    DeletebookingComponent,
    CreatebookingComponent,
    UpdatebookingComponent
  ],
  imports: [
    CommonModule,
    BookingRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class BookingModule { }
