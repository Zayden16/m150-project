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
import {OrderListModule} from 'primeng/orderlist';

import {LottieModule} from "ngx-lottie";
import player from 'lottie-web';
import { PanelmenuComponent } from './Components/panelmenu/panelmenu.component';

import { DashboardComponent } from './Components/dashboard/dashboard.component';
import { ShoppinglistComponent } from './Components/shoppinglist/shoppinglist.component';

export function playerFactory() {
  return player;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PanelmenuComponent,
    DashboardComponent,
    ShoppinglistComponent
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
    LottieModule.forRoot({ player: playerFactory }),
    OrderListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
