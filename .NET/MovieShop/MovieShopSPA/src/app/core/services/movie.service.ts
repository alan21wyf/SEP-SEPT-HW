import { Injectable } from '@angular/core';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { Movie } from 'src/app/shared/models/movie';
import {environment} from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }
  // https://localhost:44324/api/Movies/toprevenue
  //many methods that will be used by components

  //home component will call this function
  getTopRevenueMovies(): Observable<MovieCard[]>{
    // call our API, using HttpClient (XMLHttpRequest) to make GET Request
    // import HttpClientModule inside appmodule

    //read the base API url from the environment file and then append the needed URL per method
    return this.http.get<MovieCard[]>(`${environment.apiBaseURL}Movies/toprevenue`);
  }
  getMovieDetails(id:number):Observable<Movie>{
    return this.http.get<Movie>(`${environment.apiBaseURL}Movies/${id}`);
  }
}
