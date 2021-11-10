import { Component, Input, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { Cast, Genre, Movie, Trailer } from '../shared/models/movie';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  myPageTitle = "Movie Shop SPA";

  // MovieCards
  movieCards!: MovieCard[];

  // movieDetail!:Movie;
  // genres!:Genre[];
  // casts!:Cast[];
  // trailers!:Trailer[];

  // @Input() movie!:Movie;
  // @Input() genre!:Genre;
  // @Input() cast!:Cast;
  // @Input() trailer!:Trailer;
  constructor(private movieService:MovieService) { }

  ngOnInit(): void {
    // ngOnInit is one of the most important life cycle hook method in angular. 
    // It is recommended to use this method to call the API and initialize any data properties. 
    // This method will be called automatically by your angular component after calling constructor.
    
    // only when u subscribe to the observable you get the data
    // observable<MovieCard[]>
    this.movieService.getTopRevenueMovies().subscribe(
      m => {
        this.movieCards = m;
        console.log('Inside the noOnInit method of Home Component.');
        console.table(this.movieCards);
      }
    );

    // this.movieService.getMovieDetails(5).subscribe(
    //   m => {
    //     this.movieDetail = m;
    //     this.genres = m.genres;
    //     this.casts = m.casts;
    //     this.trailers = m.trailers;
    //     console.log(this.movieDetail)
    //   }
    // );
  }

}
