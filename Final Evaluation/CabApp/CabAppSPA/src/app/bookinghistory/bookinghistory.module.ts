import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookinghistoryRoutingModule } from './bookinghistory-routing.module';
import { BookinghistoryComponent } from './bookinghistory.component';
import { UpdatebookinghistoryComponent } from './updatebookinghistory/updatebookinghistory.component';
import { CreatebookinghistoryComponent } from './createbookinghistory/createbookinghistory.component';
import { DeletebookinghistoryComponent } from './deletebookinghistory/deletebookinghistory.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    BookinghistoryComponent,
    UpdatebookinghistoryComponent,
    CreatebookinghistoryComponent,
    DeletebookinghistoryComponent
  ],
  imports: [
    CommonModule,
    BookinghistoryRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class BookinghistoryModule { }
