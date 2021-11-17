import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabTypeService } from 'src/app/core/services/cabtype.service';
import { CabType } from 'src/app/shared/models/cabtypecard';

@Component({
  selector: 'app-deletecabtype',
  templateUrl: './deletecabtype.component.html',
  styleUrls: ['./deletecabtype.component.css']
})
export class DeletecabtypeComponent implements OnInit {

  deleteCabType: CabType = {
    id: 0,
    cabTypeName:''
  };
  constructor(private cabTypeService: CabTypeService, private router: Router) { }

  ngOnInit(): void {

  }

  deleteSubmit(){
    // capture the entered info and send to service
    this.cabTypeService.delete(this.deleteCabType).subscribe(
      // redirect to places
      (response) => {
        if(response){
          this.router.navigateByUrl('/');
        }
        console.log(response);

        (err: HttpErrorResponse) => {
          console.log(err.message);
        }
      }
    )
  }
}
