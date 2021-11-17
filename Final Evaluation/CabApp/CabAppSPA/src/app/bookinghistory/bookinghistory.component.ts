import { Component, Input, OnInit } from '@angular/core';
import { BookinghistoryService } from '../core/services/bookinghistory.service';
import { BookingHistory } from '../shared/models/BookingHistory';

@Component({
  selector: 'app-bookinghistory',
  templateUrl: './bookinghistory.component.html',
  styleUrls: ['./bookinghistory.component.css']
})
export class BookinghistoryComponent implements OnInit {
  bookingHists!: BookingHistory[];

  @Input() booking!:BookingHistory[];
  constructor(private bookingHistService:BookinghistoryService) { }

  ngOnInit(): void {
    this.bookingHistService.getAllBookingsHistories().subscribe(
      m => {
        this.bookingHists = m
        console.log(this.bookingHists);
      }
    )  
  }

}
