import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:"", component:HomeComponent},
  {
    path:'cabtype', loadChildren:() => import("./cabtype/cabtype.module").then(mod => mod.CabtypeModule)
  },
  {
    path:'place', loadChildren:() => import("./place/place.module").then(mod => mod.PlaceModule)
  },
  {
    path:'bookings', loadChildren:() => import("./booking/booking.module").then(mod => mod.BookingModule)
  },  
  {
    path:'bookingshistory', loadChildren:() => import("./bookinghistory/bookinghistory.module").then(mod => mod.BookinghistoryModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
