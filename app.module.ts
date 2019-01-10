import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { PopularDistanceModalComponent } from './popular-distance-modal/popular-distance-modal.component';
import { DistanceService } from './shared/distance.service';
import { HttpClientModule } from '@angular/common/http'; 

import { HttpModule } from '@angular/http';
// import { AgmCoreModule } from '@agm/core';

@NgModule({
  declarations: [
    AppComponent,
    PopularDistanceModalComponent,
  ],
  imports: [
    BrowserModule,
   HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
 
    // AgmCoreModule.forRoot({
    //     apiKey: 'YOUR_KEY'
    //   })
  ],
  providers: [DistanceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
