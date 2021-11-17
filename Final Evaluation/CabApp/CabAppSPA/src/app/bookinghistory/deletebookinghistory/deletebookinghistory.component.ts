import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookinghistoryService } from 'src/app/core/services/bookinghistory.service';
import { BookingHistory } from 'src/app/shared/models/BookingHistory';
import { DeleteBooking } from 'src/app/shared/models/DeleteBooking';

@Component({
  selector: 'app-deletebookinghistory',
  templateUrl: './deletebookinghistory.component.html',
  styleUrls: ['./deletebookinghistory.component.css']
})
export class DeletebookinghistoryComponent implements OnInit {

  deleteBookingHist: DeleteBooking = {
    id: 0
  };
  constructor(private bookingHistoryService: BookinghistoryService, private router: Router) { }

  ngOnInit(): void {
  }

  deleteSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    //console.log(this.deleteBookingHist);
    this.bookingHistoryService.delete(this.deleteBookingHist).subscribe(
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
