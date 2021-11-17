import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { HomeComponent } from './home/home.component';
import { CabtypeCardComponent } from './shared/components/cabtype-card/cabtype-card.component';
import { CabtypeBookingComponent } from './cabtype/cabtype-booking/cabtype-booking.component';
import { CabtypeBookinghistoryComponent } from './cabtype/cabtype-bookinghistory/cabtype-bookinghistory.component';
import { CabtypeModule } from './cabtype/cabtype.module';
import { BookingshistoryInfoComponent } from './shared/components/bookingshistory-info/bookingshistory-info.component';
import { BookingsInfoComponent } from './shared/components/bookings-info/bookings-info.component';
import { PlaceModule } from './place/place.module';
import { BookingModule } from './booking/booking.module';
import { BookinghistoryModule } from './bookinghistory/bookinghistory.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    CabtypeCardComponent,
    CabtypeBookingComponent,
    CabtypeBookinghistoryComponent,    
    BookingsInfoComponent,
    BookingshistoryInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports:[
    // BookingsInfoComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
