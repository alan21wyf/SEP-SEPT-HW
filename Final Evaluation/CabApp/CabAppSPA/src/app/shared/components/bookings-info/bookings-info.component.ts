import { Component, Input, OnInit } from '@angular/core';
import { Bookings } from '../../models/Bookings';

@Component({
  selector: 'app-bookings-info',
  templateUrl: './bookings-info.component.html',
  styleUrls: ['./bookings-info.component.css']
})
export class BookingsInfoComponent implements OnInit {

  
  @Input() booking!: Bookings;
  constructor() { }

  ngOnInit(): void {
  }

}
