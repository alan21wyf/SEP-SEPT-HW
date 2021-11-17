import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingComponent } from './booking.component';
import { CreatebookingComponent } from './createbooking/createbooking.component';
import { DeletebookingComponent } from './deletebooking/deletebooking.component';
import { UpdatebookingComponent } from './updatebooking/updatebooking.component';

const routes: Routes = [
  {
    path:'', component:BookingComponent,
  },
  {
    path:'create', component:CreatebookingComponent
  },
  {
    path:'delete', component:DeletebookingComponent
  },
  {
    path:'update', component:UpdatebookingComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingRoutingModule { }
