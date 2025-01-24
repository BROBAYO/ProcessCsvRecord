import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { UploadCsvComponent } from './upload-csv/upload-csv.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadCsvComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
