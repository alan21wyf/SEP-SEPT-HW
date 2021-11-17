import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlaceRoutingModule } from './place-routing.module';
import { PlaceComponent } from './place.component';
import { CreateplaceComponent } from './createplace/createplace.component';
import { UpdateplaceComponent } from './updateplace/updateplace.component';
import { DeleteplaceComponent } from './deleteplace/deleteplace.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PlaceComponent,
    CreateplaceComponent,
    UpdateplaceComponent,
    DeleteplaceComponent
  ],
  imports: [
    CommonModule,
    PlaceRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class PlaceModule { }
