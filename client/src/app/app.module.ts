import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { FooterComponent } from './footer/footer.component';
import { ToastrModule } from 'ngx-toastr';
import { RasaComponent } from './rasa/rasa.component';
import { SocketIoModule,  SocketIoConfig } from 'ngx-socket-io';

const config: SocketIoConfig = { url: 'http://localhost:8000', options: {} };





@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    RasaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    ToastrModule.forRoot(),
    SocketIoModule.forRoot(config)
    

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi:true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
