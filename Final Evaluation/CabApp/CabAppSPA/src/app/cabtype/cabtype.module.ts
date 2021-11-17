import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CabtypeRoutingModule } from './cabtype-routing.module';
import { CabtypeComponent } from './cabtype.component';
import { CreatecabtypeComponent } from './createcabtype/createcabtype.component';
import { UpdatecabtypeComponent } from './updatecabtype/updatecabtype.component';
import { DeletecabtypeComponent } from './deletecabtype/deletecabtype.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    CabtypeComponent,
    CreatecabtypeComponent,
    UpdatecabtypeComponent,
    DeletecabtypeComponent
  ],
  imports: [
    CommonModule,
    CabtypeRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CabtypeModule { }
