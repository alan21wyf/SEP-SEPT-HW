import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookinghistoryComponent } from './bookinghistory.component';
import { CreatebookinghistoryComponent } from './createbookinghistory/createbookinghistory.component';
import { DeletebookinghistoryComponent } from './deletebookinghistory/deletebookinghistory.component';
import { UpdatebookinghistoryComponent } from './updatebookinghistory/updatebookinghistory.component';

const routes: Routes = [
  {
    path:'', component:BookinghistoryComponent,
  },
  {
    path:'create', component:CreatebookinghistoryComponent
  },
  {
    path:'delete', component:DeletebookinghistoryComponent
  },
  {
    path:'update', component:UpdatebookinghistoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookinghistoryRoutingModule { }
