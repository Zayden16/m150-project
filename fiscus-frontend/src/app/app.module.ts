import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {LoginComponent} from './Components/login/login.component';
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {FormsModule}    from '@angular/forms';
import {TableModule} from 'primeng/table';
import {ChartModule} from 'primeng/chart';
import {PanelMenuModule} from 'primeng/panelmenu';
import {LottieModule} from "ngx-lottie";
import player from 'lottie-web';
import { PanelmenuComponent } from './Components/panelmenu/panelmenu.component';

import { DashboardComponent } from './Components/dashboard/dashboard.component';

export function playerFactory() {
  return player;
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CostComponent
    PanelmenuComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CardModule,
    ButtonModule,
    InputTextModule,
    FormsModule,
    TableModule,
    HttpClientModule,
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
