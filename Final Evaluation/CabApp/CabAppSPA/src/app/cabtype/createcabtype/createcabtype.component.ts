import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabTypeService } from 'src/app/core/services/cabtype.service';
import { CabType } from 'src/app/shared/models/cabtypecard';

@Component({
  selector: 'app-createcabtype',
  templateUrl: './createcabtype.component.html',
  styleUrls: ['./createcabtype.component.css']
})
export class CreatecabtypeComponent implements OnInit {

  createCabType: CabType = {
    id: 0,
    cabTypeName:''
  };
  constructor(private cabTypeService: CabTypeService, private router: Router) { }

  ngOnInit(): void {

  }

  createSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    this.cabTypeService.create(this.createCabType).subscribe(
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
