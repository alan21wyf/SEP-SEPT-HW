import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BookingHistory } from 'src/app/shared/models/BookingHistory';
import { DeleteBooking } from 'src/app/shared/models/DeleteBooking';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookinghistoryService {

  constructor(private http:HttpClient) { }
  getAllBookingsHistories():Observable<BookingHistory[]>{
    return this.http.get<BookingHistory[]>(`${environment.apiBaseURL}BookingsHistory`);
  }

  create(createRequest:BookingHistory):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}BookingsHistory/create`, createRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  update(updateRequest: BookingHistory):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}BookingsHistory/update`, updateRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  delete(deleteRequest: DeleteBooking):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}BookingsHistory/delete`, deleteRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }
}
