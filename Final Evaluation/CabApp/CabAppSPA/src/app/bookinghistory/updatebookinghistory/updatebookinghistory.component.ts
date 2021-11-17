import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookinghistoryService } from 'src/app/core/services/bookinghistory.service';
import { BookingHistory } from 'src/app/shared/models/BookingHistory';

@Component({
  selector: 'app-updatebookinghistory',
  templateUrl: './updatebookinghistory.component.html',
  styleUrls: ['./updatebookinghistory.component.css']
})
export class UpdatebookinghistoryComponent implements OnInit {
  updateBookingHist: BookingHistory = {
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
    status:'',
    comp_time:'',
    charge:0,
    feedback:''
  };
  constructor(private bookingHistoryService: BookinghistoryService, private router: Router) { }

  ngOnInit(): void {
  }

  updateSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    //console.log(this.createBookingHist);
    this.bookingHistoryService.update(this.updateBookingHist).subscribe(
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
