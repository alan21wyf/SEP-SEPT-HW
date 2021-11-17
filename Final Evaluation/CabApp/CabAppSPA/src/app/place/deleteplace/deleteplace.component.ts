import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlaceService } from 'src/app/core/services/place.service';
import { Place } from 'src/app/shared/models/Place';

@Component({
  selector: 'app-deleteplace',
  templateUrl: './deleteplace.component.html',
  styleUrls: ['./deleteplace.component.css']
})
export class DeleteplaceComponent implements OnInit {

  deletePlace: Place = {
    id: 0,
    placeName:''
  };
  constructor(private placeService: PlaceService, private router: Router) { }

  ngOnInit(): void {

  }

  deleteSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    this.placeService.delete(this.deletePlace).subscribe(
      // redirect to places
      (response) => {
        if(response){
          this.router.navigateByUrl('/place');
        }
        (err: HttpErrorResponse) => {
          console.log(err.message);
        }
      }
    )
  }
}
