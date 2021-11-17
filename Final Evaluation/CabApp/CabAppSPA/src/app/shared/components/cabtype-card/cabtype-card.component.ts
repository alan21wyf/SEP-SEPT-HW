import { Component, Input, OnInit } from '@angular/core';
import { CabType } from '../../models/cabtypecard';

@Component({
  selector: 'app-cabtype-card',
  templateUrl: './cabtype-card.component.html',
  styleUrls: ['./cabtype-card.component.css']
})
export class CabtypeCardComponent implements OnInit {
  @Input() cabTypeCard!:CabType;
  constructor() { }

  ngOnInit(): void {
  }

}
