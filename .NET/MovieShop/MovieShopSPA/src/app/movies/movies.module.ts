import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MoviesRoutingModule } from './movies-routing.module';
import { CastDetailsComponent } from './cast-details/cast-details.component';
import { TopratedComponent } from './toprated/toprated.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MoviesComponent } from './movies.component';
import { CastInfoComponent } from '../shared/components/cast-info/cast-info.component';


@NgModule({
  declarations: [
    CastDetailsComponent,
    TopratedComponent,
    MovieDetailsComponent,
    MoviesComponent,
    CastInfoComponent
  ],
  imports: [
    CommonModule,
    MoviesRoutingModule
  ]
})
export class MoviesModule { }
