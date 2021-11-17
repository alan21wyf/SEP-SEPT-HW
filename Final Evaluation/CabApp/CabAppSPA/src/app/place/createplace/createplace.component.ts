import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlaceService } from 'src/app/core/services/place.service';
import { Place } from 'src/app/shared/models/Place';

@Component({
  selector: 'app-createplace',
  templateUrl: './createplace.component.html',
  styleUrls: ['./createplace.component.css']
})
export class CreateplaceComponent implements OnInit {

  createPlace: Place = {
    id: 0,
    placeName:''
  };
  constructor(private placeService: PlaceService, private router: Router) { }

  ngOnInit(): void {

  }

  createSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    this.placeService.create(this.createPlace).subscribe(
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
