import { Component, OnInit } from '@angular/core';
import { PlaceService } from '../core/services/place.service';
import { Place } from '../shared/models/Place';

@Component({
  selector: 'app-place',
  templateUrl: './place.component.html',
  styleUrls: ['./place.component.css']
})
export class PlaceComponent implements OnInit {
  
  places!: Place[];
  constructor(private placeService:PlaceService) { }

  ngOnInit(): void {
    this.placeService.getAllPlaces().subscribe(
      p => {
        this.places = p;
        console.log(this.places);
      }
    );
  }

}
