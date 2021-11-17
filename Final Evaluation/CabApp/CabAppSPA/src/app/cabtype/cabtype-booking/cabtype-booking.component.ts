import { Component, OnInit } from '@angular/core';
import { CabTypeService } from 'src/app/core/services/cabtype.service';
import { Bookings } from 'src/app/shared/models/Bookings';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cabtype-booking',
  templateUrl: './cabtype-booking.component.html',
  styleUrls: ['./cabtype-booking.component.css']
})
export class CabtypeBookingComponent implements OnInit {

  bookings!:Bookings[];
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
    this.cabTypeService.getBookingsByCabType(this.id).subscribe(
      m => {
        this.bookings = m;
        console.log(this.bookings);
      }
    )
  }

}
