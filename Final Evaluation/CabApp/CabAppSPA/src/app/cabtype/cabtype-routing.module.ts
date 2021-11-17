import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CabtypeBookingComponent } from './cabtype-booking/cabtype-booking.component';
import { CabtypeBookinghistoryComponent } from './cabtype-bookinghistory/cabtype-bookinghistory.component';
import { CabtypeComponent } from './cabtype.component';
import { CreatecabtypeComponent } from './createcabtype/createcabtype.component';
import { DeletecabtypeComponent } from './deletecabtype/deletecabtype.component';
import { UpdatecabtypeComponent } from './updatecabtype/updatecabtype.component';

const routes: Routes = [
  {
    path:'', component:CabtypeComponent,
    children: [
      {
        path:':id/Bookings', component:CabtypeBookingComponent
      },
      {
        path:':id/BookingsHistories', component: CabtypeBookinghistoryComponent
      },
      {
        path:'create', component:CreatecabtypeComponent
      },
      {
        path:'delete', component:DeletecabtypeComponent
      },
      {
        path:'update', component:UpdatecabtypeComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CabtypeRoutingModule { }
