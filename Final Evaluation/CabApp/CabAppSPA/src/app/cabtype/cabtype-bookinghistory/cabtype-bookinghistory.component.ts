import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CabTypeService } from 'src/app/core/services/cabtype.service';
import { BookingHistory } from 'src/app/shared/models/BookingHistory';

@Component({
  selector: 'app-cabtype-bookinghistory',
  templateUrl: './cabtype-bookinghistory.component.html',
  styleUrls: ['./cabtype-bookinghistory.component.css']
})
export class CabtypeBookinghistoryComponent implements OnInit {
  
  bookingsHists!:BookingHistory[];
  id:number = 0;
  cabType!:string;
  constructor(private activeRoute: ActivatedRoute, private cabTypeService: CabTypeService) { }

  ngOnInit(): void {
    this.activeRoute.paramMap.subscribe(
      p => {
        this.id = Number(p.get('id'));
      }
    ) 
    this.cabTypeService.getCabTypeById(this.id).subscribe(
      m => {
        this.cabType = m.cabTypeName
      }
    )
    this.cabTypeService.getBookingHistoriesByCabType(this.id).subscribe(
      m => {
        this.bookingsHists = m;
        console.log(this.bookingsHists);
      }
    )
  }

}
