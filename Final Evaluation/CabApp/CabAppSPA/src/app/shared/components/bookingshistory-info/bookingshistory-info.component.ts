import { Component, Input, OnInit } from '@angular/core';
import { BookingHistory } from '../../models/BookingHistory';

@Component({
  selector: 'app-bookingshistory-info',
  templateUrl: './bookingshistory-info.component.html',
  styleUrls: ['./bookingshistory-info.component.css']
})
export class BookingshistoryInfoComponent implements OnInit {
  
  @Input() bookingHists!: BookingHistory;
  constructor() { }

  ngOnInit(): void {
  }

}
