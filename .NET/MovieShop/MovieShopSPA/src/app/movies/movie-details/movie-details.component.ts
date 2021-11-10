import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Cast, Genre, Movie, Trailer } from 'src/app/shared/models/movie';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  movie!:Movie;
  id:number = 0;
  genres!:Genre[];
  casts!:Cast[];
  trailers!:Trailer[];

  @Input() genre!:Genre;
  @Input() cast!:Cast;
  @Input() trailer!:Trailer;
  constructor(private activeRoute: ActivatedRoute, private movieService:MovieService) { }

  ngOnInit(): void {
    // ActivatedRoute => that will give us all the information of the current route/url
    // get the id from url
    // then call our api, getMovieDetails method
    console.log("inside moviedetail components");
    this.activeRoute.paramMap.subscribe(
      p => {
        this.id = Number(p.get('id'));
        console.log('movieid =' + this.id);
      }
    );
    this.movieService.getMovieDetails(this.id).subscribe(
      m => {
        this.movie = m;
        this.genres = m.genres;
        this.casts = m.casts;
        this.trailers = m.trailers;
        console.log(this.movie)
      }
    );
  }

}
