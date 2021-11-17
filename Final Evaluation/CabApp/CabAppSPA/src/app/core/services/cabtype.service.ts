import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { CabType } from 'src/app/shared/models/cabtypecard';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Bookings } from 'src/app/shared/models/Bookings';
import { BookingHistory } from 'src/app/shared/models/BookingHistory';
import { map } from 'rxjs/operators';
import { CabTypeUpdate } from 'src/app/shared/models/CabTypeUpdate';

@Injectable({
  providedIn: 'root'
})
export class CabTypeService {

  constructor(private http:HttpClient) { }

  getAllCabTypes():Observable<CabType[]>{
    return this.http.get<CabType[]>(`${environment.apiBaseURL}CabType`);
  }
  getBookingsByCabType(id:number):Observable<Bookings[]>{
    return this.http.get<Bookings[]>(`${environment.apiBaseURL}CabType/${id}/Bookings`)
  }
  getBookingHistoriesByCabType(id:number):Observable<BookingHistory[]>{
    return this.http.get<BookingHistory[]>(`${environment.apiBaseURL}CabType/${id}/BookingsHistories`)
  }
  getCabTypeById(id:number):Observable<CabType>{
    return this.http.get<CabType>(`${environment.apiBaseURL}CabType/${id}`);
  }

  create(createRequest:CabType):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}cabtype/create`, createRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  update(updateRequest: CabTypeUpdate):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}cabtype/update`, updateRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

  delete(deleteRequest: CabType):Observable<boolean>{
    return this.http.post(`${environment.apiBaseURL}cabtype/delete`, deleteRequest)
    .pipe(map((response:any) => {
      if(response){
        return true;
      }
      return false;
    }));
  }

}
