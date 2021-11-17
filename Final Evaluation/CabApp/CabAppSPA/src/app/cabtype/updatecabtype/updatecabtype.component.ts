import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CabTypeService } from 'src/app/core/services/cabtype.service';
import { CabTypeUpdate } from 'src/app/shared/models/CabTypeUpdate';

@Component({
  selector: 'app-updatecabtype',
  templateUrl: './updatecabtype.component.html',
  styleUrls: ['./updatecabtype.component.css']
})
export class UpdatecabtypeComponent implements OnInit {

  updateCabType: CabTypeUpdate = {
    oldCabTypeName:'',
    newCabTypeName:''
  };
  constructor(private cabTypeService: CabTypeService, private router: Router) { }

  ngOnInit(): void {
  }

  updateSubmit(){
    // capture the entered info and send to service
    //console.log("fdsa");
    this.cabTypeService.update(this.updateCabType).subscribe(
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
