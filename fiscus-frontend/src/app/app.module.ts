import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './Components/login/login.component';
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {ChartModule} from 'primeng/chart';
import {PanelMenuModule} from 'primeng/panelmenu';


import {LottieModule} from "ngx-lottie";
import player from 'lottie-web';
import { PanelmenuComponent } from './Components/panelmenu/panelmenu.component';

import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { UserComponent } from './Components/user/user.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {UserService} from "./Services/user.service";
import {Router} from "@angular/router";
import {JwtInterceptor} from "./Interceptors/jwt.interceptor";
import { SettingsComponent } from './Components/settings/settings.component';
import {TableModule} from "primeng/table";


export function playerFactory() {
  return player;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PanelmenuComponent,
    DashboardComponent,
    UserComponent,
    SettingsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CardModule,
    ButtonModule,
    InputTextModule,
    LottieModule.forRoot({player: playerFactory}),
    ChartModule,
    FormsModule,
    ReactiveFormsModule,
    PanelMenuModule,
    LottieModule.forRoot({player: playerFactory}),
    TableModule
  ],
  providers: [UserService, {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule {
}
