import { Component, Input, OnInit } from '@angular/core';
import { Cast } from '../../models/movie';

@Component({
  selector: 'app-cast-info',
  templateUrl: './cast-info.component.html',
  styleUrls: ['./cast-info.component.css']
})
export class CastInfoComponent implements OnInit {

  @Input() cast!: Cast;
  constructor() { }

  ngOnInit(): void {
  }

}
