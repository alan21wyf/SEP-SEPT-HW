import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Bookings } from 'src/app/shared/models/Bookings';
import { DeleteBooking } from 'src/app/shared/models/DeleteBooking';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http:HttpClient) { }
  getAllBookings():Observable<Bookings[]>{
    return this.http.get<Bookings[]>(`${environment.apiBaseURL}Bookings`);
  }


  create(createRequest:Bookings):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}Bookings/create`, createRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  update(updateRequest: Bookings):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}Bookings/update`, updateRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  delete(deleteRequest: DeleteBooking):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}Bookings/delete`, deleteRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }
}
