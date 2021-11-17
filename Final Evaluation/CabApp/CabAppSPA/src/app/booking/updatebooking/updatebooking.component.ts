import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/core/services/booking.service';
import { Bookings } from 'src/app/shared/models/Bookings';

@Component({
  selector: 'app-updatebooking',
  templateUrl: './updatebooking.component.html',
  styleUrls: ['./updatebooking.component.css']
})
export class UpdatebookingComponent implements OnInit {

  updateBooking: Bookings = {
    id:0,
    email:'',
    bookingDate:'',
    bookingTime:'',
    fromPlace:0,
    fromPlaceName:'',
    toPlace:0,
    toPlaceName:'',
    pickupAddress:'',
    landmark:'',
    pickupDate:'',
    pickupTime:'',
    cabTypeId:0,
    cabTypeName:'',
    contactNo:'',
    status:''
  };
  constructor(private bookingService: BookingService, private router: Router) { }

  ngOnInit(): void {
  }

  updateSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    //console.log(this.createBookingHist);
    this.bookingService.update(this.updateBooking).subscribe(
      // redirect to places
      (response) => {
        if(response){
          this.router.navigateByUrl('/');
        }
        (err: HttpErrorResponse) => {
          console.log(err.message);
        }
      }
    )
  }
}
