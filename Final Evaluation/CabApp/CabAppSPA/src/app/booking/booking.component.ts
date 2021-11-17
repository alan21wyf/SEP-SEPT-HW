import { Component, Input, OnInit } from '@angular/core';
import { BookingService } from '../core/services/booking.service';
import { Bookings } from '../shared/models/Bookings';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  bookings!: Bookings[];

  @Input() booking!:Bookings[];
  constructor(private bookingService:BookingService) { }

  ngOnInit(): void {
    this.bookingService.getAllBookings().subscribe(
      m => {
        this.bookings = m
        console.log(this.bookings);
      }
    )  
  }

}
