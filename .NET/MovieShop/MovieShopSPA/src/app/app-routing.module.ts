import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';

// specify all the routes required by the angular application
const routes: Routes = [
  // path/route for my home page http://localhost:4200/
  {path:"", component: HomeComponent},

  // lazily load the modules, define main route for lazy modules
  {
    path:'movies', loadChildren:() => import("./movies/movies.module").then(mod => mod.MoviesModule)
  }
  //{path:"admin/createmovie", component:CreateMovieComponent}
  //{path:"movies/:id", component: MovieDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
