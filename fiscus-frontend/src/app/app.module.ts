import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

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
import { CreateGroupComponent } from './Components/create-group/create-group.component';

export function playerFactory() {
  return player;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PanelmenuComponent,
    DashboardComponent,
    CreateGroupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CardModule,
    ButtonModule,
    InputTextModule,
    LottieModule.forRoot({ player: playerFactory }),
    ChartModule,
    PanelMenuModule,
    LottieModule.forRoot({ player: playerFactory })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
