import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Place } from 'src/app/shared/models/Place';
import { environment } from 'src/environments/environment';
import {map} from 'rxjs/operators';
import { PlaceUpdate } from 'src/app/shared/models/PlaceUpdate';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(private http:HttpClient) { }
  getAllPlaces():Observable<Place[]>{
    return this.http.get<Place[]>(`${environment.apiBaseURL}Place`);
  }

  create(createRequest:Place):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}place/create`, createRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  update(updateRequest: PlaceUpdate):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}place/update`, updateRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  delete(deleteRequest:Place):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}place/delete`, deleteRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }
}
