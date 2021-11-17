import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/core/services/booking.service';
import { DeleteBooking } from 'src/app/shared/models/DeleteBooking';

@Component({
  selector: 'app-deletebooking',
  templateUrl: './deletebooking.component.html',
  styleUrls: ['./deletebooking.component.css']
})
export class DeletebookingComponent implements OnInit {
  deleteBooking: DeleteBooking = {
    id: 0
  };
  constructor(private bookingService: BookingService, private router: Router) { }

  ngOnInit(): void {
  }

  deleteSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    //console.log(this.deleteBookingHist);
    this.bookingService.delete(this.deleteBooking).subscribe(
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
