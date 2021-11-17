import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateplaceComponent } from './createplace/createplace.component';
import { DeleteplaceComponent } from './deleteplace/deleteplace.component';
import { PlaceComponent } from './place.component';
import { UpdateplaceComponent } from './updateplace/updateplace.component';

const routes: Routes = [
  {
    path:'', component:PlaceComponent,
  },
  {
    path:'create', component:CreateplaceComponent
  },
  {
    path:'delete', component:DeleteplaceComponent
  },
  {
    path:'update', component:UpdateplaceComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlaceRoutingModule { }
