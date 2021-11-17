import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlaceService } from 'src/app/core/services/place.service';
import { PlaceUpdate } from 'src/app/shared/models/PlaceUpdate';

@Component({
  selector: 'app-updateplace',
  templateUrl: './updateplace.component.html',
  styleUrls: ['./updateplace.component.css']
})
export class UpdateplaceComponent implements OnInit {

  updatePlace: PlaceUpdate = {
    oldPlaceName:'',
    newPlaceName:''
  };
  constructor(private placeService: PlaceService, private router: Router) { }

  ngOnInit(): void {
  }

  updateSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    this.placeService.update(this.updatePlace).subscribe(
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
