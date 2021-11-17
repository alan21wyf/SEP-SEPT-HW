import { Component, OnInit } from '@angular/core';
import { CabType } from '../shared/models/cabtypecard';
import { CabTypeService } from '../core/services/cabtype.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  myPageTitle = "Cab App SPA";

  cabTypeCards!: CabType[];
  constructor(private cabtypeService:CabTypeService) { }

  ngOnInit(): void {
    this.cabtypeService.getAllCabTypes().subscribe(
      c => {
        this.cabTypeCards = c;
        console.log(this.cabTypeCards);
      }
    );
  }

}
